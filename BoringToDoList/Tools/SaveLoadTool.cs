using BoringToDoList.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace BoringToDoList.Tools
{
    internal class SaveLoadTool
    {
        private readonly string _filePath;

        public SaveLoadTool(string path)
        {
            _filePath = path;
        }
        public BindingList<ToDoModel> LoadDG()
        {
            bool isFileExist = File.Exists(_filePath);
            if (!isFileExist)
            {
                File.CreateText(_filePath).Dispose();
                return new BindingList<ToDoModel>();
            }
            using (StreamReader reader = File.OpenText(_filePath))
            {
                string text = reader.ReadToEnd();
                if (text == "") { return new BindingList<ToDoModel>(); }
                return JsonSerializer.Deserialize<BindingList<ToDoModel>>(text);
            }
        }

        public void SaveDG(BindingList<ToDoModel> ToDoList)
        {
            
            using (StreamWriter writer = File.CreateText(_filePath))
            {
                string output = JsonSerializer.Serialize(ToDoList);
                writer.Write(output);
            }
        }
    }
}
