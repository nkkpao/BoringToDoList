using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringToDoList.DataModels
{
    class ToDoModel
    {
        private bool _isDone;
        private string _text;
        public ToDoModel()
        {
            Created = DateTime.Now;
            _text = string.Empty;
        }

        public DateTime Created { get; set; }
        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        
    }
}
