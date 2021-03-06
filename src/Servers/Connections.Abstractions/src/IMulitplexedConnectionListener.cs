// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;

namespace Microsoft.AspNetCore.Connections.Experimental
{
    /// <summary>
    /// Defines an interface that represents a listener bound to a specific <see cref="EndPoint"/>.
    /// </summary>
    public interface IMultiplexedConnectionListener : IAsyncDisposable
    {
        /// <summary>
        /// The endpoint that was bound. This may differ from the requested endpoint, such as when the caller requested that any free port be selected.
        /// </summary>
        EndPoint EndPoint { get; }

        /// <summary>
        /// Stops listening for incoming connections.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="ValueTask"/> that represents the un-bind operation.</returns>
        ValueTask UnbindAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Begins an asynchronous operation to accept an incoming connection.
        /// </summary>
        /// <param name="features">A feature collection to pass options when accepting a connection.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="ValueTask{ConnectionContext}"/> that completes when a connection is accepted, yielding the <see cref="MultiplexedConnectionContext" /> representing the connection.</returns>
        ValueTask<MultiplexedConnectionContext> AcceptAsync(IFeatureCollection? features = null, CancellationToken cancellationToken = default);
    }
}
