using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuntoDeVenta.Entity;
using System.Security.Cryptography;
using System.IO;

namespace PuntoDeVenta.Library.Helpers
{
    public class UsuarioHelper
    {

        #region Encriptacion
        private readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        public string Encrypt(string plainText)
        {
            string passPhrase = "EncryptingIt!";
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            string passPhrase = "EncryptingIt!";
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
        #endregion
        public void AddUsuario(Library.Entity_Classes.Usuario usuario)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                context.TBL_USUARIOS.Add(ToTableUser(usuario));
                context.SaveChanges();
            }
        }

        private TBL_USUARIOS ToTableUser(Entity_Classes.Usuario usuario)
        {
            TBL_USUARIOS DBUser = new TBL_USUARIOS();
            DBUser.Nombre = usuario.Nombre;
            DBUser.Apellido = usuario.Apellido;
            DBUser.NombreUsuario = usuario.NombreUsuario;
            DBUser.Contraseña = Encrypt(usuario.Contraseña);
            DBUser.FechaDeCreacion = DateTime.Today;
            DBUser.ActivoAhora = 0;

            return DBUser;
        }

        public List<Entity_Classes.Usuario> GetUsuarios()
        {
            List<Entity_Classes.Usuario> usuarios = new List<Entity_Classes.Usuario>();
            Entity_Classes.Usuario usuario;
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                foreach (var item in context.TBL_USUARIOS)
                {
                    usuario = new Entity_Classes.Usuario();
                    usuario.Nombre = item.Nombre;
                    usuario.Apellido = item.Apellido;
                    usuario.UsuarioID = item.UsuarioID;
                    usuario.NombreUsuario = item.NombreUsuario;
                    usuario.Contraseña = item.Contraseña;
                    usuario.FechaDeCreacion = item.FechaDeCreacion;
                    usuario.ActivoAhora = item.ActivoAhora;
                    usuarios.Add(usuario);
                }
            }
            return usuarios;
        }

        public Entity_Classes.Usuario ToModelUsr(TBL_USUARIOS user)
        {
            Entity_Classes.Usuario usuario = new Entity_Classes.Usuario();

            usuario.UsuarioID = user.UsuarioID;
            usuario.Nombre = user.Nombre;
            usuario.NombreUsuario = user.NombreUsuario;
            usuario.Apellido = user.Apellido;
            usuario.Contraseña = user.Contraseña;
            usuario.FechaDeCreacion = user.FechaDeCreacion;
            usuario.ActivoAhora = user.ActivoAhora;


            return usuario;
        }

        public Entity_Classes.Usuario GetOnLineUser()
        {
            Entity_Classes.Usuario usuario = new Entity_Classes.Usuario();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                usuario = ToModelUsr(context.TBL_USUARIOS.SingleOrDefault(x => x.ActivoAhora == 1));
            }
            return usuario;
        }
 
    }
}
