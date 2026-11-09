using Uniaraxa.Domain.Entities;

public interface ITeacherRepository
{
    public void AddTeacher(Teacher teacher);
    public void UpdateTeacher(Teacher teacher);
    public List<Teacher> GetAllTeacher();
    public Student GetTeacherById(int id);
    public void DeleteTeacher();


}