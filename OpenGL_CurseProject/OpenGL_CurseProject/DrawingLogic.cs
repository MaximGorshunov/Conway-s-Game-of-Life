using Tao.FreeGlut;
using Tao.OpenGl;

namespace OpenGL_CurseProject
{
    public class DrawingLogic
    {
        //метод рисования моделей объектов
        public static void DrawElements()
        {
            // сфера
            Gl.glNewList(1, Gl.GL_COMPILE);
            Gl.glColor3f(1, 1, 0);
            Glut.glutSolidSphere(1, 16, 16);
            Gl.glEndList();

            // гриб
            Gl.glNewList(2, Gl.GL_COMPILE);
            Gl.glColor3f(0.7882f, 0.7098f, 0.6078f);
            Glut.glutSolidCylinder(0.5, 1, 16, 16);
            Gl.glColor3f(0.36f, 0.25f, 0.20f);
            Gl.glTranslated(0, 0, 1.5);
            Glut.glutSolidSphere(1, 16, 16);
            Gl.glEndList();

            // елка
            Gl.glNewList(3, Gl.GL_COMPILE);
            Gl.glColor3f(0.7882f, 0.7098f, 0.6078f);
            Glut.glutSolidCylinder(0.2, 0.5, 16, 16);
            Gl.glColor3f(0.576471f, 0.858824f, 0.439216f);
            Gl.glTranslated(0, 0, 0.5);
            Glut.glutSolidCone(0.7, 1, 16, 16);
            Gl.glTranslated(0, 0, 0.7);
            Glut.glutSolidCone(0.5, 1, 16, 16);
            Gl.glTranslated(0, 0, 0.7);
            Glut.glutSolidCone(0.3, 1, 16, 16);
            Gl.glEndList();

            // человек
            Gl.glNewList(4, Gl.GL_COMPILE);
            Gl.glColor3f(0.196078f, 0.196078f, 0.8f);

            Gl.glTranslated(0.5, 0, 0);
            Glut.glutSolidCylinder(0.2, 1, 16, 16); // нога

            Gl.glTranslated(-0.5, 0, 0);
            Glut.glutSolidCylinder(0.2, 1, 16, 16); // нога

            Gl.glColor3f(1f, 0.5f, 0.0f);
            Gl.glTranslated(0.25, 0, 0.8);
            Glut.glutSolidCylinder(0.5, 1, 16, 16); // туловище

            Gl.glTranslated(0.7, 0, 0.18);
            Gl.glRotated(-27, 0, 1, 0);
            Glut.glutSolidCylinder(0.2, 0.8, 16, 16); // рука

            Gl.glTranslated(-1.3, 0, 0.7);
            Gl.glRotated(59, 0, 1, 0);
            Glut.glutSolidCylinder(0.2, 0.8, 16, 16); // рука

            Gl.glColor3f(0.7882f, 0.7098f, 0.6078f);
            Gl.glTranslated(0.11, 0, 1.29);
            Glut.glutSolidSphere(0.5, 16, 16); // голова

            Gl.glEndList();
        }
    }
}
