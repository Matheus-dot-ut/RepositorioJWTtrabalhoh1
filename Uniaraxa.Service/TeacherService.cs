using Uniaraxa.Domain.Entities;
using Uniaraxa.Domain.Interfaces;

namespace Uniaraxa.Service;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;

    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public Teacher Inserir(Teacher teacher)
    {
        Validar(teacher);
        return _repository.Inserir(teacher);
    }

    public bool Atualizar(int id, Teacher teacher)
    {
        Validar(teacher);
        teacher.Id = id;
        return _repository.Atualizar(teacher);
    }

    public IEnumerable<Teacher> ListarTodos() => _repository.ListarTodos();

    public Teacher? BuscarPorId(int id) => _repository.BuscarPorId(id);

    public bool Remover(int id) => _repository.Remover(id);

    private static void Validar(Teacher teacher)
    {
        if (string.IsNullOrWhiteSpace(teacher.Name))
            throw new ArgumentException("O nome é obrigatório.");
        if (string.IsNullOrWhiteSpace(teacher.EMail))
            throw new ArgumentException("O e-mail é obrigatório.");
        if (teacher.DataAdmissao > DateTime.Today)
            throw new ArgumentException("A data de admissão não pode ser futura.");
    }
}
