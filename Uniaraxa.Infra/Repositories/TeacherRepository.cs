using Uniaraxa.Domain.Entities;
using Uniaraxa.Domain.Interfaces;

namespace Uniaraxa.Infra.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly List<Teacher> _teachers = new();
    private int _nextId = 1;
    private readonly object _lock = new();

    public Teacher Inserir(Teacher teacher)
    {
        lock (_lock)
        {
            teacher.Id = _nextId++;
            _teachers.Add(teacher);
            return teacher;
        }
    }

    public bool Atualizar(Teacher teacher)
    {
        lock (_lock)
        {
            var existente = _teachers.FirstOrDefault(t => t.Id == teacher.Id);
            if (existente is null) return false;

            existente.Name = teacher.Name;
            existente.EMail = teacher.EMail;
            existente.UrlLattes = teacher.UrlLattes;
            existente.DataAdmissao = teacher.DataAdmissao;
            return true;
        }
    }

    public IEnumerable<Teacher> ListarTodos()
    {
        lock (_lock) return _teachers.ToList();
    }

    public Teacher? BuscarPorId(int id)
    {
        lock (_lock) return _teachers.FirstOrDefault(t => t.Id == id);
    }

    public bool Remover(int id)
    {
        lock (_lock)
        {
            var teacher = _teachers.FirstOrDefault(t => t.Id == id);
            return teacher is not null && _teachers.Remove(teacher);
        }
    }
}
