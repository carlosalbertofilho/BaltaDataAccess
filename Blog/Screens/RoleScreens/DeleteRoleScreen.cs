﻿using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

namespace Blog.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar Perfil");
            Console.WriteLine("--------------");

            ListRolesScreen.ListRoles();

            Console.WriteLine("--------------");

            try
            {
                DeleteRole();
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível deletar o perfil");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu Perfis");
                Console.ReadKey();
                MenuRoleScreen.Load();
            }
        }

        private static void DeleteRole()
        {
            var id = InputHandler.GetId("Digite o Id do perfil: ");

            Console.WriteLine($"Você deseja deletar o perfil com Id: {id}? (S/N)");
            var option = Console.ReadLine();

            switch (option?.ToUpper())
            {
                case "S":
                    var repository = new Repository<Role>();
                    repository.Delete(id);
                    Console.WriteLine("Perfil deletado com sucesso!");

                    break;
                default:
                    Console.WriteLine("Opção invalida, operação cancelada!");
                    break;
            }
        }
    }
}