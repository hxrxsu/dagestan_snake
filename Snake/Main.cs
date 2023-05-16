namespace Snake;

public partial class Main : Form {

    private readonly List<Figure> _snake = new();
    private Figure _food = new();
    private readonly Random _random = new();
    private Directions _direction = Directions.Left;
    private readonly int _width = 16;
    private readonly int _height = 16;
    private readonly int _maxWidth;
    private readonly int _maxHeight;
    private int _scoreCounter;

    public Main() {
        InitializeComponent();
        _maxWidth = frameRenderer.Width / _width;
        _maxHeight = frameRenderer.Height / _height;
    }

    private void KeyDownHandler(object sender, KeyEventArgs e) {
        _direction = e.KeyCode switch {
            Keys.Left when _direction != Directions.Right => Directions.Left,
            Keys.Right when _direction != Directions.Left => Directions.Right,
            Keys.Up when _direction != Directions.Down => Directions.Up,
            Keys.Down when _direction != Directions.Up => Directions.Down,
            _ => _direction
        };
    }

    private void StartGame(object sender, EventArgs e) {
        RestartGame();
    }

    private void GameTimerHandler(object sender, EventArgs e) {
        for (int i = _snake.Count - 1; i >= 0; i--) {
            if (i == 0) {
                switch (_direction) {
                    case Directions.Left:
                        _snake[i].X--;
                        break;
                    case Directions.Right:
                        _snake[i].X++;
                        break;
                    case Directions.Down:
                        _snake[i].Y++;
                        break;
                    case Directions.Up:
                        _snake[i].Y--;
                        break;
                }

                if (_snake[i].X == _food.X && _snake[i].Y == _food.Y) {
                    EatFood();
                }
                
                if (_snake[i].X < 0 || _snake[i].X > _maxWidth || _snake[i].Y < 0 || _snake[i].Y > _maxHeight)
                    GameOver();

                for (int j = 1; j < _snake.Count; j++) {
                    if (_snake[j].X == _food.X && _snake[j].Y == _food.Y)
                        EatFood();
                    if (_snake[i].X == _snake[j].X && _snake[i].Y == _snake[j].Y) 
                        GameOver();
                }
            }
            else {
                _snake[i].X = _snake[i - 1].X;
                _snake[i].Y = _snake[i - 1].Y;
            }
        }

        frameRenderer.Invalidate();
    }

    private void UpdateFrameHandler(object sender, PaintEventArgs e) {
        var graphics = e.Graphics;
        foreach (var snakePart in _snake) {
            graphics.FillRectangle(Brushes.Black, new Rectangle
            (
                snakePart.X * _width,
                snakePart.Y * _width,
                _width, _height
            ));
        }

        graphics.FillRectangle(Brushes.DarkRed, new Rectangle
        (
            _food.X * _width,
            _food.Y * _height,
            _width, _height
        ));
    }

    private void RestartGame() {
        _snake.Clear();
        UpdateScore();
        startButton.Enabled = false;
        
        _snake.Add(new Figure { X = 13, Y = 10 });
        _snake.Add(new Figure());

        _food = new Figure {
            X = _random.Next(2, _maxWidth), 
            Y = _random.Next(2, _maxHeight)
        };

        gameTimer.Start();
    }

    private void EatFood() {
        UpdateScore();
        _snake.Add(new Figure {
            X = _snake[^1].X,
            Y = _snake[^1].Y
        });
        _food = new Figure {
            X = _random.Next(2, _maxWidth), 
            Y = _random.Next(2, _maxHeight)
        };
    }

    private void GameOver() {
        gameTimer.Stop();
        startButton.Enabled = true;
    }

    private void UpdateScore() {
        if (!gameTimer.Enabled) {
            _scoreCounter = -3;
        }

        _scoreCounter += 3;
        score.Text = $"Очки: {_scoreCounter}";
    }
}