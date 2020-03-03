using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
* Olaoluwa Anthony-Egorp
* November 15th, 2019
* 
* I, Olaoluwa Anthony-Egorp, 000776467, certify that all code submitted is my
own work; that I have not copied it from any other source. I also certify that
I have not allowed my work to be copied by others. 

This is a program that filters HTML files by making sure tags are opened and closed
     */


namespace Lab4B
{
    public partial class Form1 : Form
    {
        //List that stores all tags, open and closed
        List<String> htmlTags = new List<String>();
        //Open file dialog object that allows user to open their html file
        OpenFileDialog opf = new OpenFileDialog();
        //String that contains the path to the file in the directory
        string filePath = " ";
        //String that contains and displys formatted file path
        string filename = "";
        public Form1()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// This is the method that is is responsible for loading the file. It uses the open file dialog to open up the file selection for the user
        /// </summary>
        /// <param name="sender">Open File Dialog object</param>
        /// <param name="e">Arguments</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //Setting the Inital Directory of the open file dialog to the C drive        
            opf.InitialDirectory = @"C:\\";
            //Filter for the open file dialog set to being strictly HTML files
            opf.Filter = "HTML files (*.html) |*.html";
            //Setting the filter index to 1 current selected for file dialog box
            opf.FilterIndex = 1;
            //Goes back to the directory that was last selected, for easy file navigation
            opf.RestoreDirectory = true;

            //If statement to check if user has selected file
            if (opf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //This line is setting the file path variable to the name of the file
                    filePath = opf.FileName;
                
                    //This line sets the value of the file name variable to the formatted file name
                    filename = Path.GetFileName(opf.InitialDirectory + filePath);

              
                    //Streamreader object which will read the file and filter
                    StreamReader reader = new StreamReader(filePath);
                    //String variable that will contain tags that are read character by character
                    string tags = "";
                    //String array that will hold all HTML tags that are unfiltered
                    string[] parts;
                    //List that will contain all filtered tags from the parts string array
                    List<String> filter = new List<String>();
                   
                    //While loop that goes through the entire HTML file
                    while (!reader.EndOfStream)
                    {
                        //Character variable which will read HTML file character by character
                        char tag = (char)reader.Read();
                        //Making every character lower case before comparing
                        tag = Char.ToLower(tag);
                       
                        //Checking to see if tag starts with a '<' character, to represent that it is a tag
                        if (tag.Equals('<'))
                        {
                            //Appending first character in between the angle brackets to the string to form an HTML tag
                            tags += tag;
                            //While loop that checks if the end of the tag has not been reached
                            while (!tag.Equals('>'))
                            {
                                //tag being read character by character
                                tag = (char)reader.Read();
                                //Transforming each character to lowercase before it is compared
                                tag = Char.ToLower(tag);
                                //Appending each character that is read one by one
                                tags += tag;
                            }
                            //Adding a space to the end of the tag that will be used to split all the gathered tags into their own variables
                            tags += " ";
                        }
                        
                    }
                    //Splitting string array by space that was added to the end of each character
                    parts = tags.Split(' ');
                    
                    //For loop that runs through unfiltered array
                    for (int i = 0; i < parts.Length; i++)
                    {
                        //If string starts with an angle bracket
                       if (parts[i].StartsWith("<"))
                        {
                            //This is responsible for the tags that have other attributes in the tag. These attributes are removed and the remainder of the tag is added to the filtered list. If they do end with an angle bracket then they are added to the list
                            if (!parts[i].EndsWith(">")){
                                filter.Add(parts[i] + ">");
                            }
                            else {
                                filter.Add(parts[i]);
                            }
                        }
                    }
                    
                   
                    //Foreach loop that adds each tag in filtered list to the final list HTML tags
                   foreach (string s in filter)
                    {
                        htmlTags.Add(s);
                    }
                    
                   foreach (String h in htmlTags)
                    {
                        if (!h.Contains("/") && !h.Contains("br") && !h.Contains("hr") && !h.Contains("img"))
                        {
                            htmlListBox.Items.Add("Found opening tag: " + h);
                        }
                        else if (h.Contains("/"))
                        {
                            htmlListBox.Items.Add("Found closing tag: " + h);
                        }
                        else if (h.Contains("br") || h.Contains("hr") || h.Contains("img"))
                        {
                            htmlListBox.Items.Add("Found non-container tag: " + h);
                        }
                    }

                }
                //End of Stream error exception handling with message
                catch (EndOfStreamException eos)
                {
                    Console.WriteLine($"End of stream has been reached {eos.Message}");
                }
                //End of File error exception handling with message
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"File not found {ex.Message}");
                }
                //Input/Output error exception handling with message
                catch (IOException ei)
                {
                    Console.WriteLine($"Input/Output Error {ei.Message}");
                }
                //General Exception error exception handling with message
                catch (Exception er)
                {
                    Console.WriteLine($"General error {er.Message}");

                }
            }

            
        }

        /// <summary>
        /// This is the method that is is responsible for checking the tag list using the stack generic collection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Try catch enwrapping the whole method
            try
            {
                //Stack object that will stack all opening tags
                Stack tagStack = new Stack();
                //Foreach loop that adds tag based on conditions
                foreach (string t in htmlTags)
                {
                    //if statement that adds the tag onto the stack if it does not have a '/', 'img', 'hr', 'br'
                    if (!t.ToLower().Contains("/") && !t.ToLower().Contains("img") && !t.ToLower().Contains("hr") && !t.ToLower().Contains("br"))
                    {
                        tagStack.Push(t);
                    }
                    //Else if statement that removes the tag from the stack if the tag in the html tags list contains the filtered text in the stack, and if the tag has a '/' closing symbol
                    else if (t.ToLower().Contains(tagStack.Peek().ToString().Substring(2, tagStack.Peek().ToString().Length - 3)) && t.ToLower().Substring(1, 1).Equals("/"))
                    {
                        tagStack.Pop();
                    }                   
                }

                //If the stack has tags at the end of the check, then it is unbalanced, else if it is 0, it is a balanced HTML file
                if (tagStack.Count > 0)
                {
                    statusLabel.Text = filename + " has unbalanced tags";
                }
                else
                {
                    statusLabel.Text = filename + " has balanced tags";
                }
                //Invalid Operation exception handling with Message box 
            }catch(InvalidOperationException ioe)
            {
                MessageBox.Show($"{ioe.Message}", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Exception handling with Message box
            catch (Exception exe)
            {
                MessageBox.Show($"{exe.Message}", "Exception error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
