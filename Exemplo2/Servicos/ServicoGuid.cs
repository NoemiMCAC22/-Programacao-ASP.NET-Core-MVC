namespace Exemplo2.Servicos
{
    public class ServicoGuid : IServicoGUID
    {
        public string IDUnico { get; set; }
        public ServicoGuid() 
        {
            this.IDUnico = Guid.NewGuid().ToString();
        }
    }
}
