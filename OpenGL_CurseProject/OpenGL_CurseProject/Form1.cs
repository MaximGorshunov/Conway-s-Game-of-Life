using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using OpenGL_CurseProject.Enums;
using Tao.DevIl;

namespace OpenGL_CurseProject
{
    public partial class MainForm : Form
    {
        private const int FIELD_HEIGHT = 16;
        private const int FIELD_WIDTH = 25;
        private const int FIELD_SCALE = 2;
        private const int FIELD_OFFSET_X = 25;
        private const int FIELD_OFFSET_Y = 14;

        private const string CROSS_TEXTURE = "Textures\\cross-96.png";
        private const string MAP_TEXTURE = "Textures\\map.png";

        private float globalTime = 0;

        private int cursorPosX = 1;
        private int cursorPosY = 1;
        private int cursorPosZ = 1;

        private double cursorTranslateX = 0.0;
        private double cursorTranslateY = 0.0;
        private double cursorTranslateZ = 0.1;

        private int selectedCreature = 4;

        uint pointerTextureObj;
        uint mapTextureObj;

        //массив с данными о точках обзора
        private float[,] CameraPosition = new float[5, 7];

        private Game game = new Game();

        public MainForm()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            Il.ilInit(); 
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glLineWidth(1.0f);

            _ = LoadTexture(CROSS_TEXTURE, out pointerTextureObj);
            _ = LoadTexture(MAP_TEXTURE, out mapTextureObj);

            //Установка значений для поворота и переноса точки обзора
            CameraPosition[0, 0] = 0;
            CameraPosition[0, 1] = 2;
            CameraPosition[0, 2] = -45;
            CameraPosition[0, 3] = -45;
            CameraPosition[0, 4] = 1;
            CameraPosition[0, 5] = 0;
            CameraPosition[0, 6] = 0;

            CameraPosition[1, 0] = 0;
            CameraPosition[1, 1] = 0;
            CameraPosition[1, 2] = -50;
            CameraPosition[1, 3] = -80;
            CameraPosition[1, 4] = 1;
            CameraPosition[1, 5] = 0;
            CameraPosition[1, 6] = 0;

            CameraPosition[2, 0] = 0;
            CameraPosition[2, 1] = 0;
            CameraPosition[2, 2] = -45;
            CameraPosition[2, 3] = 0;
            CameraPosition[2, 4] = 1;
            CameraPosition[2, 5] = 0;
            CameraPosition[2, 6] = 0;

            CameraPosition[3, 0] = 0;
            CameraPosition[3, 1] = 3;
            CameraPosition[3, 2] = -55;
            CameraPosition[3, 3] = -90;
            CameraPosition[3, 4] = 0;
            CameraPosition[3, 5] = 0;
            CameraPosition[3, 6] = 1;

            CameraPosition[4, 0] = 0;
            CameraPosition[4, 1] = 3;
            CameraPosition[4, 2] = -55;
            CameraPosition[4, 3] = 90;
            CameraPosition[4, 4] = 0;
            CameraPosition[4, 5] = 0;
            CameraPosition[4, 6] = 1;

            comboBoxView.SelectedIndex = 0;
            comboBoxCreatures.SelectedIndex = 3;
            comboBoxPresets.SelectedIndex = 0;

            RenderTimer.Start();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            var oldTime = globalTime;
            if (game.Status == GameStatus.Started)
            {
                globalTime += (float)RenderTimer.Interval / 1000;
                if ((int)oldTime < (int)globalTime)
                {
                    game.GameLogic();
                    game.CountPopulation();
                }
                labelPopulation.Text = game.Population.ToString();
                labelTime.Text = Math.Round(globalTime, 2).ToString();
            }
            Draw();
        }

        private void Draw()
        {
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3d(0, 0, 0);
            Gl.glPushMatrix();

            //определение точки обзора
            int camera = comboBoxView.SelectedIndex;
            Gl.glTranslated(CameraPosition[camera, 0], CameraPosition[camera, 1], CameraPosition[camera, 2]);
            if (camera > 2)
            {
                //операции последовательного поворота системы координат по разным осям
                Gl.glRotated(CameraPosition[camera, 3], CameraPosition[camera, 4], CameraPosition[camera, 5], CameraPosition[camera, 6]);
                Gl.glRotated(60 * CameraPosition[camera, 3] / 90, 0, 1, 0);
            }
            else
            {
                Gl.glRotated(CameraPosition[camera, 3], CameraPosition[camera, 4], CameraPosition[camera, 5], CameraPosition[camera, 6]);
            }

            Gl.glPushMatrix();

            DrawingLogic.DrawElements();

            DrawMatrix();
            DrawCursor();

            var periodTime = globalTime - (int)globalTime;

            DrawCreatures(periodTime);

            Gl.glColor3f(0.74902f, 0.847059f, 0.847059f);
            Glut.glutSolidTorus(300, 400, 16, 16);
            Gl.glTranslated(0, 0, -150);
            Glut.glutSolidCube(200);

            Gl.glPopMatrix();
            Gl.glPopMatrix();

            Gl.glFlush();
            AnT.Invalidate();
        }

        private void DrawMatrix()
        {

            Gl.glBegin(Gl.GL_LINES);
            for (int ax = 0; ax < FIELD_WIDTH + 1; ax++)
            {
                Gl.glVertex3d(ax * FIELD_SCALE - FIELD_OFFSET_X, -FIELD_OFFSET_Y, -1);
                Gl.glVertex3d(ax * FIELD_SCALE - FIELD_OFFSET_X, FIELD_HEIGHT * FIELD_SCALE - FIELD_OFFSET_Y, -1);
            }
            for (int bx = 0; bx < FIELD_HEIGHT + 1; bx++)
            {
                Gl.glVertex3d(-FIELD_OFFSET_X, bx * FIELD_SCALE - FIELD_OFFSET_Y, -1);
                Gl.glVertex3d(FIELD_WIDTH * FIELD_SCALE - FIELD_OFFSET_X, bx * FIELD_SCALE - FIELD_OFFSET_Y, -1);
            }
            Gl.glEnd();

            //рисование плоскости поля игры

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mapTextureObj);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3f(0, 1, 1);
            Gl.glVertex3d(-25, -14, -1);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(-25, 18, -1);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(25, 18, -1);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(25, -14, -1);
            Gl.glTexCoord2f(0, 1);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }


        public void DrawCursor()
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, pointerTextureObj);
                
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glPushMatrix();
            Gl.glTranslated(cursorTranslateX, cursorTranslateY, cursorTranslateZ);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-cursorPosX - FIELD_OFFSET_X + 1, -cursorPosY - FIELD_OFFSET_Y + 1, -cursorPosZ);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(-cursorPosX - FIELD_OFFSET_X + 1, cursorPosY - FIELD_OFFSET_Y + 1, -cursorPosZ);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(cursorPosX - FIELD_OFFSET_X + 1, cursorPosY - FIELD_OFFSET_Y + 1, -cursorPosZ);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(cursorPosX - FIELD_OFFSET_X + 1, -cursorPosY - FIELD_OFFSET_Y + 1, -cursorPosZ);
            Gl.glTexCoord2f(0, 1);
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }

        public void DrawCreatures(float periodTime)
        {
            for (int i = 0; i < FIELD_WIDTH; i++)
            {
                for (int j = 0; j < FIELD_HEIGHT; j++)
                {
                    float posX = (i + 0.5f) * FIELD_SCALE;
                    float posY = (j + 0.5f) * FIELD_SCALE;
                    var creature = game.creatures[i, j];
                    switch (creature.Status)
                    {
                        case CreatureStatus.Mature:

                            Gl.glPushMatrix();
                            Gl.glTranslatef(posX - FIELD_OFFSET_X, posY - FIELD_OFFSET_Y, -0.5f);
                            Gl.glCallList(selectedCreature);
                            Gl.glPopMatrix();
                            break;

                        case CreatureStatus.Growing:

                            Gl.glPushMatrix();
                            Gl.glTranslatef(posX - FIELD_OFFSET_X, posY - FIELD_OFFSET_Y, -0.5f);
                            Gl.glScaled(periodTime, periodTime, periodTime);
                            Gl.glCallList(selectedCreature);
                            Gl.glPopMatrix();
                            break;

                        case CreatureStatus.Dying:

                            Gl.glPushMatrix();
                            Gl.glTranslatef(posX - FIELD_OFFSET_X, posY - FIELD_OFFSET_Y, -0.5f);
                            Gl.glScaled(1 - periodTime, 1 - periodTime, 1 - periodTime);
                            Gl.glCallList(selectedCreature);
                            Gl.glPopMatrix();
                            break;

                        default:
                            break;

                    }
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            PauseGame();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            game.Clear();
            globalTime = 0;
            labelPopulation.Text = game.Population.ToString();
            labelTime.Text = Math.Round(globalTime, 2).ToString();
            game.Status = GameStatus.Stoped;
            buttonPause.Visible = false;
            buttonReset.Visible = false;
            if (!buttonStart.Visible) buttonStart.Visible = true;
        }

        private void StartGame()
        {
            RenderTimer.Start();
            game.Status = GameStatus.Started;
            buttonPause.Visible = true;
            buttonReset.Visible = true;
            buttonStart.Visible = false;
        }

        private void PauseGame()
        {
            game.Status = GameStatus.Paused;
            buttonPause.Visible = false;
            buttonStart.Visible = true;
        }

        private void AnT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    cursorTranslateY = (cursorTranslateY + FIELD_SCALE) % (FIELD_HEIGHT * FIELD_SCALE);
                    break;

                case Keys.S:
                    cursorTranslateY = (cursorTranslateY + FIELD_HEIGHT * FIELD_SCALE - FIELD_SCALE) % (FIELD_HEIGHT * FIELD_SCALE);
                    break;

                case Keys.A:
                    cursorTranslateX = (cursorTranslateX + FIELD_WIDTH * FIELD_SCALE - FIELD_SCALE) % (FIELD_WIDTH * FIELD_SCALE);
                    break;

                case Keys.D:
                    cursorTranslateX = (cursorTranslateX + FIELD_SCALE) % (FIELD_WIDTH * FIELD_SCALE);
                    break;

                case Keys.Enter:
                    game.AddCreature((int)cursorTranslateX / FIELD_SCALE, (int)cursorTranslateY / FIELD_SCALE);
                    break;
                case Keys.Space:
                    if (game.Status == GameStatus.Started)
                    {
                        PauseGame();
                    }
                    else
                    {
                        StartGame();
                    }
                    break;
                default:
                    break;
            }
        }

        private void comboBoxPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPresets.SelectedIndex)
            {
                case 0:
                    game.Clear();
                    break;
                case 1:
                    game.Clear();
                    game.Glider();
                    break;
                case 2:
                    game.Clear();
                    game.Barge();
                    break;
                case 3:
                    game.Clear();
                    game.SpaceShip();
                    break;
                default:
                    break;
            }
        }

        private void comboBoxCreatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxCreatures.SelectedIndex)
            {
                case 0:
                    selectedCreature = 1;
                    break;
                case 1:
                    selectedCreature = 2;
                    break;
                case 2:
                    selectedCreature = 3;
                    break;
                case 3:
                    selectedCreature = 4;
                    break;
                default:
                    break;
            }
        }

        private static bool LoadTexture(string texturePath, out uint objId)
        {
            objId = 0;
            Il.ilGenImages(1, out var imageId);
            Il.ilBindImage(imageId);

            if (!Il.ilLoadImage(texturePath))
            {
                return false;
            }

            int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
            switch (bitspp)
            {
                case 24:
                    objId = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                    break;
                case 32:
                    objId = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                    break;
            }
            Il.ilDeleteImages(1, ref imageId);

            return true;
        }

        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            uint texObject;
            Gl.glGenTextures(1, out texObject);
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
            switch (Format)
            {

                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

            }
            return texObject;
        }
    }
}
