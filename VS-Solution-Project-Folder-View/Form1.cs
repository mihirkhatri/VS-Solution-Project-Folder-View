using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Configuration;

namespace VS_Solution_Project_Folder_View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StringBuilder htmlBuilder = new StringBuilder();

        string[] excludeFolders;

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = FolderDlg.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                FolderPathTextBox.Text = FolderDlg.SelectedPath;
            }
        }

        
        private void GenerateViewButton_Click(object sender, EventArgs e)
        {
            GenerateViewButton.Enabled = false;

            excludeFolders = ConfigurationSettings.AppSettings["folderToExclude"].Split(',');

            htmlBuilder.Clear();

            htmlBuilder.Append(@"
                <style>
                    .projectsolution {color : red;}  
                    .project {color : blue;}  
                    .solution {color : green;} 
                    .solutionname {list-style-type : none; color : gray;}
                    .projectname {list-style-type : none; color : gray;}
                    .projectsolution ul {margin-left : 0px;padding-left : 0px;}
                    .project ul {margin-left : 0px;padding-left : 0px;}
                    .solution ul {margin-left : 0px;padding-left : 0px;}
                    
                    body {font-family : Verdana;}
                    ul {list-style-type : disc;}
                </style>
                <script>
                    function showhide(e) {
                        if(e.checked) {
                            var eles = document.querySelectorAll('.folder');
                            eles.forEach(x => x.style.display = 'none');
                        } else {
                            var eles = document.querySelectorAll('.folder');
                            eles.forEach(x => x.style.display = 'list-item');
                        }
                    }
                </script>
                <div>
                    Show only the Project and Solutions : <input type='checkbox' id='hidefolders' onchange='showhide(this)' />
                </div>
            ");
            SearchRecursiveFolder(FolderPathTextBox.Text);

            string htmlFile = FolderPathTextBox.Text + ".html";
            File.WriteAllText(htmlFile, htmlBuilder.ToString());

            GenerateViewButton.Enabled = true;

            System.Diagnostics.Process.Start(htmlFile);
        }


        private void SearchRecursiveFolder(string FolderPath)
        {
            htmlBuilder.Append("<ul>");

            bool isFolderToExclude = false;

            foreach (string s in excludeFolders)
            {
                if (FolderPath.EndsWith(s))
                {
                    isFolderToExclude = true;
                    break;
                }
            }
            if (!isFolderToExclude)
            {
                DirectoryInfo di = new DirectoryInfo(FolderPath);

                List<string> projectFiles = di.GetFiles().Where(w => w.Name.EndsWith(".csproj")).Select(s => s.Name).ToList();
                List<string> solutionFiles = di.GetFiles().Where(w => w.Name.EndsWith(".sln")).Select(s => s.Name).ToList();

                bool isProject = projectFiles.Count() > 0;
                bool isSolution = solutionFiles.Count() > 0;

                if (isProject && isSolution)
                {
                    htmlBuilder.Append("<li class='projectsolution'>" + di.Name);
                    htmlBuilder.Append("<ul>");
                    foreach (string s in solutionFiles)
                    {
                        htmlBuilder.Append(string.Format("<li class='solutionname'>..{0}</li>",s));
                    }
                    foreach (string s in projectFiles)
                    {
                        htmlBuilder.Append(string.Format("<li class='projectname'>....{0}</li>",s));
                    }
                    htmlBuilder.Append("</ul></li>");
                }
                if (isProject)
                {
                    htmlBuilder.Append("<li class='project'>" + di.Name);
                    htmlBuilder.Append("<ul>");
                    foreach (string s in projectFiles)
                    {
                        htmlBuilder.Append(string.Format("<li class='projectname'>....{0}</li>", s));
                    }
                    htmlBuilder.Append("</ul></li>");
                }
                else if (isSolution)
                {
                    htmlBuilder.Append("<li class='solution'>" + di.Name);
                    htmlBuilder.Append("<ul>");
                    foreach (string s in solutionFiles)
                    {
                        htmlBuilder.Append(string.Format("<li class='solutionname'>..{0}</li>", s));
                    }
                    htmlBuilder.Append("</ul></li>");
                }
                else
                {
                    htmlBuilder.Append("<li class='folder'>" + di.Name + "</li>");
                }

                foreach (DirectoryInfo d in di.GetDirectories())
                {
                    SearchRecursiveFolder(d.FullName);
                    htmlBuilder.Append("</ul>");
                }
            }
        }
    }
}
