using WinFormsApp2.WinFormsApp2;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private CommandParser commandParser;
        private CommandExecutor _commandExecutor;

        public Form1()
        {
            InitializeComponent();

            commandParser = new CommandParser();
            _commandExecutor = new CommandExecutor(pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics(), Color.Black, pictureBox1);
        }


        private string[] commands = Array.Empty<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            commands = richTextBox1.Text.ToLower().Split('\n');

            if (commandParser.ParseCommands(commands))
            {
                _commandExecutor.ExecuteCommands(commandParser.GetDelayedCommands());

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string singleLineCommand = textBox1.Text.ToLower().Trim();
                if (string.IsNullOrEmpty(singleLineCommand))
                {
                    MessageBox.Show("You haven't entered a command!");
                    e.Handled = true;
                    return;
                }

                if (!commandParser.ParseCommands(singleLineCommand))
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    commandParser.ParseCommands(commands);
                    _commandExecutor.ExecuteCommands(commandParser.GetDelayedCommands());
                    e.Handled = true; // Prevents the Enter key from being processed further
                }
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //Set the default file extension and
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            //Display the SaveFile Dialog.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Gets the file name from the dialog window
                string fileName = saveFileDialog1.FileName;

                //Gets the program text from the RichTextBox.
                string[] lines = richTextBox1.Lines;

                //writes the program to the file.
                File.WriteAllLines(fileName, lines);
                MessageBox.Show("Program saved!");
                richTextBox1.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Sets the default file extension and filter.
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            //Displays the OpenFileDialog window.
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                try
                {
                    //Reads all lines from the text file and  displays them in the richtextbox1
                    string[] lines = File.ReadAllLines(fileName);
                    richTextBox1.Lines = lines;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}