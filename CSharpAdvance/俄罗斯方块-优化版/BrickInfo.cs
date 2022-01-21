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
        g
    }

    class BrickInfo
    {    
        //方块位置集合
        //
        public Position[] positions = new Position[4];

        //方块的下位置极值
        //
        public int bottomposY;

        //改变方块位置、方向
        //
        public void Move(E_BrickShape brickShape,int dir, Position oriPos)
        {
            positions[0] = oriPos;
            switch (brickShape)
            {
                case E_BrickShape.a:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    positions[1] = new Position(oriPos.posX, oriPos.posY + 1);
                    positions[2] = new Position(oriPos.posX + 2, oriPos.posY + 1);
                    positions[3] = new Position(oriPos.posX + 2, oriPos.posY);
                    break;

                case E_BrickShape.b:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    switch (dir)
                    {
                        case 1:
                            positions[1] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[2] = new Position(oriPos.posX, oriPos.posY + 2);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        case 2:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX - 4, oriPos.posY);
                            positions[3] = new Position(oriPos.posX + 2, oriPos.posY);
                            break;
                        case 3:
                            positions[1] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[2] = new Position(oriPos.posX, oriPos.posY - 2);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        case 4:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY);
                            positions[3] = new Position(oriPos.posX + 4, oriPos.posY);
                            break;
                        default:
                            break;
                    }
                    break;
                case E_BrickShape.c:
                    Console.ForegroundColor = ConsoleColor.Green;
                    switch (dir)
                    {
                        case 1:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[3] = new Position(oriPos.posX + 2, oriPos.posY);
                            break;
                        case 2:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        case 3:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        case 4:
                            positions[1] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        default:
                            break;
                    }
                    break;
                case E_BrickShape.d:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    switch (dir)
                    {
                        case 1:
                            positions[1] = new Position(oriPos.posX + 2, oriPos.posY + 1);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        case 2:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY + 1);
                            positions[2] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[3] = new Position(oriPos.posX + 2, oriPos.posY);
                            break;
                        case 3:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[3] = new Position(oriPos.posX - 2, oriPos.posY - 1);
                            break;
                        case 4:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY - 1);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        default:
                            break;
                    }
                    break;
                case E_BrickShape.e:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    switch (dir)
                    {
                        case 1:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX - 2, oriPos.posY + 1);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        case 2:
                            positions[1] = new Position(oriPos.posX + 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX, oriPos.posY - 1);
                            positions[3] = new Position(oriPos.posX - 2, oriPos.posY - 1);
                            break;
                        case 3:
                            positions[1] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY);
                            positions[3] = new Position(oriPos.posX + 2, oriPos.posY - 1);
                            break;
                        case 4:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[3] = new Position(oriPos.posX + 2, oriPos.posY + 1);
                            break;
                        default:
                            break;
                    }
                    break;
                case E_BrickShape.f:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    switch (dir)
                    {
                        case 1:
                            positions[1] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[2] = new Position(oriPos.posX, oriPos.posY - 1);
                            positions[3] = new Position(oriPos.posX - 2, oriPos.posY - 1);
                            break;
                        case 2:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY);
                            positions[3] = new Position(oriPos.posX + 2, oriPos.posY - 1);
                            break;
                        case 3:
                            positions[1] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY + 1);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        case 4:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX - 2, oriPos.posY + 1);
                            positions[3] = new Position(oriPos.posX + 2, oriPos.posY);
                            break;
                        default:
                            break;
                    }
                    break;
                case E_BrickShape.g:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    switch (dir)
                    {
                        case 1:
                            positions[1] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY - 1);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        case 2:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY + 1);
                            positions[3] = new Position(oriPos.posX + 2, oriPos.posY);
                            break;
                        case 3:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY + 1);
                            positions[2] = new Position(oriPos.posX, oriPos.posY + 1);
                            positions[3] = new Position(oriPos.posX, oriPos.posY - 1);
                            break;
                        case 4:
                            positions[1] = new Position(oriPos.posX - 2, oriPos.posY);
                            positions[2] = new Position(oriPos.posX + 2, oriPos.posY);
                            positions[3] = new Position(oriPos.posX - 2, oriPos.posY - 1);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            //更新方块的下位置极值
            for (int i = 0; i < positions.Length; i++)
            {
                if(i == 0)
                {
                    bottomposY = positions[i].posY;
                }
                else
                {
                    if(positions[i].posY > bottomposY)
                    {
                        bottomposY = positions[i].posY;
                    }
                }
            }
        }

        public BrickInfo(E_BrickShape brickShape, int dir, Position oriPos)
        {
            Move(brickShape, dir, oriPos);
        }

    }
}
