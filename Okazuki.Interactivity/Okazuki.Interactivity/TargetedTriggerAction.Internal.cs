﻿using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Okazuki.Interactivity
{
    public abstract class TargetedTriggerAction : TriggerAction
    {
        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register(
                "TargetObject", 
                typeof(object), 
                typeof(TargetedTriggerAction), 
                new PropertyMetadata(null));

        public Type TargetType { get; private set; }

        public object TargetObject
        {
            get { return (object)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        protected object Target
        {
            get
            {
                return this.TargetObject ?? this.AssociatedObject;
            }
        }

        public TargetedTriggerAction(Type targetType) : base(typeof(DependencyObject))
        {
            this.TargetType = targetType;
        }

    }
}
