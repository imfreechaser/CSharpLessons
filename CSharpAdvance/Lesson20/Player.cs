using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20
{
    public class Player
    {
        public string name;

        [RemindNoModify]
        public int Hp { get; set; }

        [RemindNoModify]
        public int atk;
        public int dfd;
        public int PosX, PosY;


    }
    sealed class RemindNoModifyAttribute : Attribute
    {

    }
}
