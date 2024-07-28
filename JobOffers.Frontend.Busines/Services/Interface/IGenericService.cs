﻿using JobOffers.Frontend.Domain.Models;
using JobOffers.Frontend.Domain.Models.LambdaManagement.Models;

namespace JobOffers.Frontend.Busines.Services.Interface
{
    public interface IGenericService<TEntityViewModel> where TEntityViewModel : Entity
    {
        #region READ
        Task<IList<TEntityViewModel>?> GetEntitiesAsync(string uri, string? token, string? includes = null);
        Task<TEntityViewModel?> GetEntitiesAsync(string uri, string? token, int id, string? includes = null);
        Task<IList<TEntityViewModel>?> GetEntitiesAsync(string uri, string? token, FilterDataModel filterDataModel);
        #endregion

        #region CREATE
        Task<TEntityViewModel?> CreateAsync(string uri, string? token, TEntityViewModel entity);
        Task<IList<TEntityViewModel>?> CreateAsync(string uri, string? token, IList<TEntityViewModel> entities);
        #endregion

        #region UPDATE
        Task<TEntityViewModel?> UpdateAsync(string uri, string? token, TEntityViewModel entity);
        Task<IList<TEntityViewModel>?> UpdateAsync(string uri, string? token, IList<TEntityViewModel> entities);
        #endregion

        #region DELETE
        Task<TEntityViewModel?> DeleteAsync(string uri, string? token, TEntityViewModel entity);
        Task<IList<TEntityViewModel>?> DeleteAsync(string uri, string? token, IList<TEntityViewModel> entities);
        #endregion
    }
}