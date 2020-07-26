namespace WhereAreYou.MeetApi.ApiClient
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading;
    using System.Threading.Tasks;
    using WhereAreYou.Core.Entity;
    using WhereAreYou.Core.Requests;
    using WhereAreYou.Core.Responses;
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.5.0.0 (NJsonSchema v10.1.15.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IMeetApiClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<CreatedMeet> CreateAsync(CreateMeet body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<CreatedMeet> CreateAsync(CreateMeet body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<MeetResponse> GetAsync(Token token);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<MeetResponse> GetAsync(Token token, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Meet>> GetAllAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Meet>> GetAllAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task AddPositionAsync(AddOrUpdatePosition body, Token token);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task AddPositionAsync(AddOrUpdatePosition body, Token token,System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UpdatePositionAsync(AddOrUpdatePosition body, Token token);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UpdatePositionAsync(AddOrUpdatePosition body, Token token, System.Threading.CancellationToken cancellationToken);

    }
}
