﻿// Ix.Presentation.Blazor.Controls
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ix.Connector;
using Ix.Presentation.Blazor.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Ix.Presentation;
using Ix.Presentation.Blazor.Services;
using Ix.Presentation.Blazor;

namespace Ix.Presentation.Blazor.Controls.RenderableContent
{
    /// <summary>
    ///  Base class for complex componenets with viewmodel support.
    /// </summary>
    public class RenderableViewModelComponentBase<T> : RenderableComponentBase, IRenderableViewModelBase where T : RenderableViewModelBase, new()
    {

        [Inject]
        private ViewModelCacheService _viewModelCache { get; set; }

        private TwinContainerObject _twinContainer;
        [Parameter]
        public TwinContainerObject TwinContainer
        {
            get { return _twinContainer; }
            set 
            {
                _twinContainer = value;
                ViewModelInitialization(value);
            }
        }

        private void ViewModelInitialization(TwinContainerObject container)
        {
            var viewModel = _viewModelCache.GetViewModelFromCache(container.Id);
            if (viewModel != null)
            {
                try
                {
                    ViewModel = (T)viewModel;
                    return;
                }
                catch
                {
                    //if there was problem with getting viewmodel, try to create new one
                    ViewModel = new() { Model = container.Twin };
                }
            }
            //look if viewModel is already in cache, if no, add it there
            else
            {
                ViewModel = new() { Model = container.Twin };
                _viewModelCache.AddViewModelToCache(container.Id, ViewModel);
            }
           
        }


        public T ViewModel { get; set; }
    }
}
