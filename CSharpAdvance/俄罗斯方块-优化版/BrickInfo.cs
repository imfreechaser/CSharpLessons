using System;
using System.Collections.Generic;
using System.Text;

namespace 俄罗斯方块_优化版
{
    /// <summary>
    /// 方块形状
    /// </summary>
    enum E_BrickShape
    {
        a,
        b,
        c,
        d,
        e,
        f,
        g,
        wall,
        dynWall
    }

    class BrickInfo
    {    
        //每个对象的各种方向形状集合
        //
        List<Position[]> brickList;

        //从外部获取形状信息的索引器
        //
        public Position[] this[int index]
        {
            get
            {
                //索引合法性判断
                if (index < 0 || index > brickList.Count - 1)
                    return null;
                return brickList[index];
            }
        }

        //从外部获取到brickList的长度
        //
        public int BrickListCount
        {
            get => brickList.Count;
        }

        public BrickInfo(E_BrickShape brickShape)
        {
            //通过方块对象的类型，得到关于这个对象的所有方向的形状位置信息（相对位置）
            switch (brickShape)
            {
                case E_BrickShape.a:
                    brickList = new List<Position[]>()
                    {
                        new Position[]{new Position(0,1),new Position(2,1),new Position(2,0)}
                    };
                    break;
                case E_BrickShape.b:
                    brickList = new List<Position[]>()
                    {
                        new Position[]{new Position(0,1),new Position(0,2),new Position(0,-1)},
                        new Position[]{new Position(-2,0),new Position(-4,0),new Position(2,0)},
                        new Position[]{new Position(0,1),new Position(0,-2),new Position(0,-1)},
                        new Position[]{new Position(-2,0),new Position(4,0),new Position(2,0)}
                    };
                    break;
                case E_BrickShape.c:
                    brickList = new List<Position[]>()
                    {
                        new Position[]{new Position(-2,0),new Position(0,1),new Position(2,0)},
                        new Position[]{new Position(-2,0),new Position(0,1),new Position(0,-1)},
                        new Position[]{new Position(-2,0),new Position(2,0),new Position(0,-1)},
                        new Position[]{new Position(0,1),new Position(2,0),new Position(0,-1)}
                    };
                    break;
                case E_BrickShape.d:
                    brickList = new List<Position[]>()
                    {
                        new Position[]{new Position(2,1),new Position(2,0),new Position(0,-1)},
                        new Position[]{new Position(-2,1),new Position(0,1),new Position(2,0)},
                        new Position[]{new Position(-2,0),new Position(0,1),new Position(-2,-1)},
                        new Position[]{new Position(-2,0),new Position(2,-1),new Position(0,-1)}
                    };
                    break;
                case E_BrickShape.e:
                    brickList = new List<Position[]>()
                    {
                        new Position[]{new Position(-2,0),new Position(-2,1),new Position(0,-1)},
                        new Position[]{new Position(2,0),new Position(0,-1),new Position(-2,-1)},
                        new Position[]{new Position(0,1),new Position(2,0),new Position(2,-1)},
                        new Position[]{new Position(-2,0),new Position(0,1),new Position(2,1)}
                    };
                    break;
                case E_BrickShape.f:
                    brickList = new List<Position[]>()
                    {
                        new Position[]{new Position(0,1),new Position(0,-1),new Position(-2,-1)},
                        new Position[]{new Position(-2,0),new Position(2,0),new Position(2,-1)},
                        new Position[]{new Position(0,1),new Position(2,1),new Position(0,-1)},
                        new Position[]{new Position(-2,0),new Position(-2,1),new Position(2,0)}
                    };
                    break;
                case E_BrickShape.g:
                    brickList = new List<Position[]>()
                    {
                        new Position[]{new Position(0,1),new Position(2,-1),new Position(0,-1)},
                        new Position[]{new Position(-2,0),new Position(2,1),new Position(2,0)},
                        new Position[]{new Position(-2,1),new Position(0,1),new Position(0,-1)},
                        new Position[]{new Position(-2,0),new Position(2,0),new Position(-2,-1)}
                    };
                    break;
                default:
                    brickList = new List<Position[]>();
                    break;
            }
        }

    }
}
