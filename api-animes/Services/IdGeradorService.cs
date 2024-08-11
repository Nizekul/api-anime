using System.Reflection.Emit;

namespace api_animes.Services
{
    public class IdGeradorService
    {
        private static IdGeradorService _id;
        private static readonly object _locker = new object();
        private readonly Dictionary<Type, int> _idAtual;

        private IdGeradorService()
        {
            _idAtual = new Dictionary<Type, int>();
        }

        public static IdGeradorService Instancia
        {
            get
            {
                lock (_locker)
                {
                    if (_id == null)
                    {
                        _id = new IdGeradorService();
                    }
                    return _id;
                }
            }
        }

        public int PegarProxId<T>()
        {
            lock ( _locker)
            {
                var type = typeof(T);

                if (!_idAtual.ContainsKey(type))
                {
                    _idAtual[type] = 0;
                }

                return ++_idAtual[type];
            }
        }
    }
}
