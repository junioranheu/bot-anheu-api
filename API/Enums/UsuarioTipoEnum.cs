using System.ComponentModel;

namespace API.Enums
{
    public enum UsuarioTipoEnum
    {
        Administrador = 1,

        [Description("Usuário")]
        Usuario = 2
    }
}
