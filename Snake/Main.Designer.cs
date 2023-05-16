namespace Snake; 

partial class Main {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
        frameRenderer = new PictureBox();
        score = new Label();
        gameTimer = new System.Windows.Forms.Timer(components);
        startButton = new Button();
        ((System.ComponentModel.ISupportInitialize)frameRenderer).BeginInit();
        SuspendLayout();
        // 
        // frameRenderer
        // 
        frameRenderer.BackColor = Color.YellowGreen;
        frameRenderer.Location = new Point(12, 12);
        frameRenderer.Name = "frameRenderer";
        frameRenderer.Size = new Size(776, 406);
        frameRenderer.TabIndex = 0;
        frameRenderer.TabStop = false;
        frameRenderer.Paint += UpdateFrameHandler;
        // 
        // score
        // 
        score.AutoSize = true;
        score.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
        score.Location = new Point(12, 421);
        score.Name = "score";
        score.Size = new Size(54, 20);
        score.TabIndex = 1;
        score.Text = "";
        // 
        // gameTimer
        // 
        gameTimer.Interval = 75;
        gameTimer.Tick += GameTimerHandler;
        // 
        // startButton
        // 
        startButton.BackColor = Color.Transparent;
        startButton.Location = new Point(713, 421);
        startButton.Name = "startButton";
        startButton.Size = new Size(75, 23);
        startButton.TabIndex = 2;
        startButton.Text = "Начать";
        startButton.UseVisualStyleBackColor = false;
        startButton.Click += StartGame;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.WindowFrame;
        ClientSize = new Size(800, 450);
        Controls.Add(startButton);
        Controls.Add(score);
        Controls.Add(frameRenderer);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Main";
        Text = "Snake";
        KeyDown += KeyDownHandler;
        ((System.ComponentModel.ISupportInitialize)frameRenderer).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox frameRenderer;
    private Label score;
    private System.Windows.Forms.Timer gameTimer;
    private Button startButton;
}