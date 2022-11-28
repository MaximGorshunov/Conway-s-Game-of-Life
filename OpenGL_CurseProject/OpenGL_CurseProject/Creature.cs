using OpenGL_CurseProject.Enums;

namespace OpenGL_CurseProject
{
    public class Creature
    {
        public CreatureStatus Status { get; set; }
        
        public Creature()
        {
            Status = CreatureStatus.Dead;
        }
    }
}
