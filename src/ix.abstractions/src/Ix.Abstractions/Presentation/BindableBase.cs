﻿// Ix.Abstractions
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

namespace Ix.Presentation
{    
    using System.ComponentModel; 
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents base class for bindable objects.
    /// </summary>
    public class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Sets the property and raises <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="member">Member</param>
        /// <param name="val">New value</param>
        /// <param name="propertyName">Property name</param>
        protected virtual void SetProperty<T>(ref T member, T val,
            [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Implementation of <see cref="INotifyPropertyChanged.PropertyChanged"/>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
