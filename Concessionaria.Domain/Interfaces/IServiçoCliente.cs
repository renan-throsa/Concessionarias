﻿using Concessionaria.Dominio.Modelos;

namespace Concessionaria.Dominio.Interfaces
{
    public interface IServiçoCliente
    {
        ModeloResultadoDaOperação FindAll();

        Task<ModeloResultadoDaOperação> FindById(int id);       

        Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoCliente modelo);       

        Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoCliente modelo);        

        Task<ModeloResultadoDaOperação> Remove(int id);        

        
        
    }
}
