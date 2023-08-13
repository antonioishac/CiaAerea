using CiaAerea.Contexts;
using CiaAerea.Entities;
using CiaAerea.ViewModels;

namespace CiaAerea.Services;

public class AeronaveService
{ 
    private readonly CiaAereaContexts _context;

    public AeronaveService(CiaAereaContexts context)
    {
        _context = context;
    }

    public DetalhesAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        var aeronave = new Aeronave(
            dados.Fabricante, 
            dados.Modelo, 
            dados.Codigo);

        _context.Add(aeronave);
        _context.SaveChanges();

        return new DetalhesAeronaveViewModel
        (
            aeronave.Id,
            aeronave.Fabricante,
            aeronave.Modelo,
            aeronave.Codigo

        );
    }

    public IEnumerable<ListarAeronaveViewModel> ListarAeronaves()
    {
        return _context.Aeronaves.Select(a => new ListarAeronaveViewModel(a.Id, a.Modelo, a.Codigo));
    }

    public DetalhesAeronaveViewModel? ListarAeronavePeloId(int id)
    {
        
        var aeronave = _context.Aeronaves.Find(id);

        if (aeronave != null)
        {
            return new DetalhesAeronaveViewModel
            (
                aeronave.Id,
                aeronave.Fabricante,
                aeronave.Modelo,
                aeronave.Codigo
            );
        }

        return null;
    }

    public DetalhesAeronaveViewModel? AtualizarAeronave(AtualizarAeronaveViewModel dados)
    {
        var aeronave = _context.Aeronaves.Find(dados.Id);

        if (aeronave != null)
        {
            aeronave.Codigo = dados.Codigo;
            aeronave.Fabricante = dados.Fabricante;
            aeronave.Modelo = dados.Modelo;

            _context.Update(aeronave);
            _context.SaveChanges();

            return new DetalhesAeronaveViewModel(aeronave.Id, aeronave.Fabricante, aeronave.Modelo, aeronave.Codigo);
        }
        return null;
    }

    public void ExcluirAeronave(int id)
    {
        var aeronave = _context.Aeronaves.Find(id);

        if (aeronave != null)
        {
            _context.Remove(aeronave);
            _context.SaveChanges();
        }
    }
}