using MiniShop.Frontend.Client.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore;
using WebApiClientCore.Exceptions;
using Weick.Orm.Core;
using Weick.Orm.Core.Result;

namespace MiniShop.Frontend.Client.HttpApis
{
    public class ExecuteApi
    {
        public async static Task<ResultModel<T>> ExecuteApiAsync<T>(Func<ITask<ResultModel<T>>> action)
        {
            int statusCode;
            string msg;
            try
            {
                var result = await action();
                return result;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ApiInvalidConfigException configException)
            {
                // 请求配置异常
                msg = configException.Message;
                statusCode = 500;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ApiResponseStatusException statusException)
            {
                // 响应状态码异常
                msg = statusException.Message;
                statusCode = (int)statusException.StatusCode;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ApiException apiException)
            {
                // 抽象的api异常
                msg = apiException.Message;
                statusCode = 500;
            }
            catch (HttpRequestException ex) when (ex.InnerException is SocketException socketException)
            {
                // socket连接层异常
                msg = socketException.Message;
                statusCode = 500;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ValidationException validationException)
            {
                // 数据验证异常
                msg = validationException.Message;
                statusCode = 400;
            }
            catch (HttpRequestException ex)
            {
                // 请求异常
                msg = ex.Message;
                statusCode = 500;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                statusCode = 500;
            }
            return new ResultModel<T> { Success = false, Msg = msg, Status = statusCode };
        }
        public async static Task<ResultModel<List<T>>> ExecuteApiAsync<T>(Func<ITask<ResultModel<List<T>>>> action)
        {
            int statusCode;
            string msg;
            try
            {
                var result = await action();
                return result;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ApiInvalidConfigException configException)
            {
                // 请求配置异常
                msg = configException.Message;
                statusCode = 500;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ApiResponseStatusException statusException)
            {
                // 响应状态码异常
                msg = statusException.Message;
                statusCode = (int)statusException.StatusCode;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ApiException apiException)
            {
                // 抽象的api异常
                msg = apiException.Message;
                statusCode = 500;
            }
            catch (HttpRequestException ex) when (ex.InnerException is SocketException socketException)
            {
                // socket连接层异常
                msg = socketException.Message;
                statusCode = 500;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ValidationException validationException)
            {
                // 数据验证异常
                msg = validationException.Message;
                statusCode = 400;
            }
            catch (HttpRequestException ex)
            {
                // 请求异常
                msg = ex.Message;
                statusCode = 500;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                statusCode = 500;
            }
            return new ResultModel<List<T>> { Success = false, Msg = msg, Status = statusCode };
        }
        public async static Task<ResultModel<PagedList<T>>> ExecuteApiAsync<T>(Func<ITask<ResultModel<PagedList<T>>>> action)
        {
            int statusCode;
            string msg;
            try
            {
                var result = await action();
                return result;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ApiInvalidConfigException configException)
            {
                // 请求配置异常
                msg = configException.Message;
                statusCode = 500;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ApiResponseStatusException statusException)
            {
                // 响应状态码异常
                msg = statusException.Message;
                statusCode = (int)statusException.StatusCode;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ApiException apiException)
            {
                // 抽象的api异常
                msg = apiException.Message;
                statusCode = 500;
            }
            catch (HttpRequestException ex) when (ex.InnerException is SocketException socketException)
            {
                // socket连接层异常
                msg = socketException.Message;
                statusCode = 500;
            }
            catch (HttpRequestException ex) when (ex.InnerException is ValidationException validationException)
            {
                // 数据验证异常
                msg = validationException.Message;
                statusCode = 400;
            }
            catch (HttpRequestException ex)
            {
                // 请求异常
                msg = ex.Message;
                statusCode = 500;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                statusCode = 500;
            }
            return new ResultModel<PagedList<T>> { Success = false, Msg = msg, Status = statusCode };
        }
    }
}
