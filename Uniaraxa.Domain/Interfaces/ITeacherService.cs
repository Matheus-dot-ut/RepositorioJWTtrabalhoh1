using Uniaraxa.Domain.Entities;

namespace Uniaraxa.Domain.Interfaces;

public interface ITeacherService
{
    Teacher Inserir(Teacher teacher);
    bool Atualizar(int id, Teacher teacher);
    IEnumerable<Teacher> ListarTodos();
    Teacher? BuscarPorId(int id);
    bool Remover(int id);
}
