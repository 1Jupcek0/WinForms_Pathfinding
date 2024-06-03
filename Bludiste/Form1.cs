using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bludiste {
    public partial class Form1:Form {
        public Form1() {
            InitializeComponent();
            for(int i = 0;i < 20;i++) {
                for(int j = 0;j < 20;j++) {
                    pole[i,j] = 0;
                }
            }
        }
        Color[] color = new Color[]{
            Color.Bisque,
            Color.AliceBlue,
            Color.Blue,
            Color.BlueViolet,
            Color.Brown,
            Color.BurlyWood,
            Color.CadetBlue,
            Color.Chartreuse,
            Color.Chocolate,
            Color.Coral,
            Color.Cornsilk,
            Color.Crimson,
            Color.Cyan,
            Color.DarkBlue,
            Color.DarkCyan,
            Color.DarkGoldenrod,
            Color.DarkGray,
            Color.DarkGreen,
            Color.DarkKhaki,
            Color.DarkMagenta,
            Color.DarkOliveGreen,
            Color.DarkOrange,
            Color.DarkOrchid,
            Color.DarkRed,
            Color.DarkSalmon,
            Color.DarkSeaGreen,
            Color.DarkSlateBlue,
            Color.DarkSlateGray,
            Color.DarkTurquoise,
            Color.DarkViolet,
            Color.DeepPink,
            Color.DeepSkyBlue,
            Color.DimGray,
            Color.DodgerBlue,
            Color.Firebrick,
            Color.FloralWhite,
            Color.ForestGreen,
            Color.Fuchsia,
            Color.Gainsboro,
            Color.GhostWhite,
            Color.Gold,
            Color.Goldenrod,
            Color.Gray,
            Color.Green,
            Color.GreenYellow,
            Color.Honeydew,
            Color.HotPink,
            Color.IndianRed,
            Color.Indigo,
            Color.Ivory,
            Color.Khaki,
            Color.Lavender,
            Color.LavenderBlush,
            Color.LawnGreen,
            Color.LemonChiffon,
            Color.LightBlue,
            Color.LightCoral,
            Color.LightCyan,
            Color.LightGoldenrodYellow,
            Color.LightGray,
            Color.LightGreen,
            Color.LightPink,
            Color.LightSalmon,
            Color.LightSeaGreen,
            Color.LightSkyBlue,
            Color.LightSlateGray,
            Color.LightSteelBlue,
            Color.LightYellow,
            Color.Lime,
            Color.LimeGreen,
            Color.Linen,
            Color.Magenta,
            Color.Maroon,
            Color.MediumAquamarine,
            Color.MediumBlue,
            Color.MediumOrchid,
            Color.MediumPurple,
            Color.MediumSeaGreen,
            Color.MediumSlateBlue,
            Color.MediumSpringGreen,
            Color.MediumTurquoise,
            Color.MediumVioletRed,
            Color.MidnightBlue,
            Color.MintCream,
            Color.MistyRose,
            Color.Moccasin,
            Color.NavajoWhite,
            Color.Navy,
            Color.OldLace,
            Color.Olive,
            Color.OliveDrab,
            Color.Orange,
            Color.OrangeRed,
            Color.Orchid,
            Color.PaleGoldenrod,
            Color.PaleGreen,
            Color.PaleTurquoise,
            Color.PaleVioletRed,
            Color.PapayaWhip,
            Color.PeachPuff,
            Color.Peru,
            Color.Pink,
            Color.Plum,
            Color.PowderBlue,
            Color.Purple,
            Color.Red,
            Color.RosyBrown,
            Color.RoyalBlue,
            Color.SaddleBrown,
            Color.Salmon,
            Color.SandyBrown,
            Color.SeaGreen,
            Color.SeaShell,
            Color.Sienna,
            Color.Silver,
            Color.SkyBlue,
            Color.SlateBlue,
            Color.SlateGray,
            Color.Snow,
            Color.SpringGreen,
            Color.SteelBlue,
            Color.Tan,
            Color.Teal,
            Color.Thistle,
            Color.Tomato,
            Color.Transparent,
            Color.Turquoise,
            Color.Violet,
            Color.Wheat,
            Color.WhiteSmoke,
            Color.Yellow,
            Color.YellowGreen
            };
        int[,] pole = new int[20,20];
        Point zacatek, konec;
        //zeď
        private void VykreslitZed(Point bunka) {
            try {
                if(pole[bunka.X,bunka.Y] == 0) {
                    pole[bunka.X,bunka.Y] = -1;
                } else if(pole[bunka.X,bunka.Y] == -1) {
                    pole[bunka.X,bunka.Y] = 0;
                }
            } catch(Exception) { }
        }
        //pozice
        private Point ZjistiBunku(Point bod) {
            return new Point(bod.X / 21,bod.Y / 21);
        }
        private void TableLayout_MouseClick(object sender,MouseEventArgs e) {
            Point current = ZjistiBunku(new Point(e.Location.X,e.Location.Y));
            if(e.Button == MouseButtons.Left) {
                VykreslitZed(current);
            } else if(e.Button == MouseButtons.Right) {
                if(pole[current.X,current.Y] == -1) {
                    pole[current.X,current.Y] = 0;
                }
            }
            TableLayout.Refresh();
        }
        Point current;
        private void TableLayout_MouseMove(object sender,MouseEventArgs e) {
            Point b = ZjistiBunku(new Point(e.Location.X,e.Location.Y));
            if(e.Button == MouseButtons.Left) {
                if(current != b) {
                    current = b;
                    VykreslitZed(ZjistiBunku(new Point(e.Location.X,e.Location.Y)));
                }
            }
        }


        private void TableLayout_Paint(object sender,PaintEventArgs e) {
            Graphics grf = e.Graphics;
            Rectangle rect;

            for(int i = 0;i < 20;i++) {
                for(int j = 0;j < 20;j++) {
                    if(pole[i,j] == -1) {
                        rect = new Rectangle(i * 21,j * 21,21,21);
                        SolidBrush stetec = new SolidBrush(Color.Brown);
                        grf.FillRectangle(stetec,rect);
                    } else if(pole[i,j] == -5) {
                        grf.DrawString("S",new Font(new FontFamily("Times New Roman"),15,FontStyle.Regular),Brushes.Green,i * 21,j * 21,StringFormat.GenericDefault);
                    } else if(pole[i,j] == -10) {
                        grf.DrawString("E",new Font(new FontFamily("Times New Roman"),15,FontStyle.Regular),Brushes.Red,i * 21,j * 21,StringFormat.GenericDefault);
                    } else if(pole[i,j] > 0) {
                        SolidBrush br = new SolidBrush(color[pole[i,j]]);
                        grf.DrawString(pole[i,j].ToString(),new Font(new FontFamily("Times New Roman"),10,FontStyle.Regular),br,i * 21,j * 21,StringFormat.GenericDefault);
                    }
                      //zalená - cesta
                      else if(pole[i,j] == -15) {
                        rect = new Rectangle(i * 21,j * 21,21,21);
                        SolidBrush stetec = new SolidBrush(Color.Green);
                        grf.FillRectangle(stetec,rect);
                    }
                }
            }
        }


        //drag
        private void MouseDownDrag(object sender,MouseEventArgs e) {
            TextBox tctb = (TextBox)sender;
            DoDragDrop(tctb.Text,DragDropEffects.Copy);
        }
        private void TableLayout_DragEnter(object sender,DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void TableLayout_DragDrop(object sender,DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
            if(e.Data.GetDataPresent(typeof(String))) {
                Point p = ZjistiBunku(this.PointToClient(new Point(e.X,e.Y)));
                if("S" == (String)e.Data.GetData(typeof(String))) {
                    if(pole[zacatek.X,zacatek.Y] == -5 && zacatek != p) {
                        pole[zacatek.X,zacatek.Y] = 0;
                        zacatek = p;
                        pole[p.X,p.Y] = -5;
                    } else {
                        zacatek = p;
                        pole[p.X,p.Y] = -5;
                    }
                } else if("E" == (String)e.Data.GetData(typeof(String))) {

                    if(pole[konec.X,konec.Y] == -10 && konec != p) {
                        pole[konec.X,konec.Y] = 0;
                        konec = p;
                        pole[p.X,p.Y] = -10;
                    } else {
                        konec = p;
                        pole[p.X,p.Y] = -10;
                    }
                }
            }
            TableLayout.Refresh();
        }

        //#########
        bool konecNalezen = false;
        int konecCislo;
        private void BtnVlna_Click(object sender,EventArgs e) {
            if(zacatek == new Point(0,0) && konec == new Point(0,0)) return;
            DrawWave();
        }
        void DrawWave() {
            Okolo(new Point(zacatek.X,zacatek.Y),1);
            for(int round = 1;round < 400;round++) {
                for(int i = 0;i < 20;i++) {
                    for(int j = 0;j < 20;j++) {
                        if(pole[i,j] == round) {
                            Okolo(new Point(i,j),round + 1);
                        }
                    }
                }
                if(konecNalezen == true) {
                    konecCislo = round + 1;
                    break;
                }
            }

            TableLayout.Refresh();
        }
        void Okolo(Point stred,int cislo) {
            //levo
            if(Kontrola(new Point(stred.X - 1,stred.Y)) == true) {
                if(pole[stred.X - 1,stred.Y] != -10) {
                    if(pole[stred.X - 1,stred.Y] == 0 && pole[stred.X - 1,stred.Y] != -1) {
                        pole[stred.X - 1,stred.Y] = cislo;
                    }
                } else { konecNalezen = true; konec = new Point(stred.X - 1,stred.Y); }
            }
            //pravo
            if(Kontrola(new Point(stred.X + 1,stred.Y)) == true) {
                if(pole[stred.X + 1,stred.Y] != -10) {
                    if(pole[stred.X + 1,stred.Y] == 0 && pole[stred.X + 1,stred.Y] != -1) {
                        pole[stred.X + 1,stred.Y] = cislo;
                    }
                } else { konecNalezen = true; konec = new Point(stred.X + 1,stred.Y); }
            }
            //nahore
            if(Kontrola(new Point(stred.X,stred.Y + 1)) == true) {
                if(pole[stred.X,stred.Y + 1] != -10) {
                    if(pole[stred.X,stred.Y + 1] == 0 && pole[stred.X,stred.Y + 1] != -1) {
                        pole[stred.X,stred.Y + 1] = cislo;
                    }
                } else { konecNalezen = true; konec = new Point(stred.X,stred.Y + 1); }
            }
            //dole
            if(Kontrola(new Point(stred.X,stred.Y - 1)) == true) {
                if(pole[stred.X,stred.Y - 1] != -10) {
                    if(pole[stred.X,stred.Y - 1] == 0 && pole[stred.X,stred.Y - 1] != -1) {
                        pole[stred.X,stred.Y - 1] = cislo;
                    }
                } else { konecNalezen = true; konec = new Point(stred.X,stred.Y - 1); }
            }
        }


        bool Kontrola(Point stred) {
            try {
                pole[stred.X,stred.Y].ToString();
                return true;
            } catch(Exception) {
                return false;
            }

        }

        //############
        private void NajitBtn(object sender,EventArgs e) {
            if(zacatek == new Point(0,0) && konec == new Point(0,0)) return;
            if(!konecNalezen) DrawWave();
            int posun = konecCislo;
            Point current = konec;
            while(posun != 1) {
                for(int i = -1;i < 2;i++) {
                    for(int j = -1;j < 2;j++) {
                        try {
                            if(pole[current.X + i,current.Y + j] == posun - 1 & pole[current.X + i,current.Y + j] != 0 & pole[current.X + i,current.Y + j] != -1 & pole[current.X + i,current.Y + j] != -10) {
                                pole[current.X + i,current.Y + j] = -15;
                                posun--;
                                current = new Point(current.X + i,current.Y + j);
                            }
                        } catch(Exception) { }
                    }
                }
            }
            TableLayout.Refresh();


        }

        private void TableLayout_Layout(object sender,LayoutEventArgs e) {
            TableLayout.Size = new Size(420, 420);
        }
    }
}
