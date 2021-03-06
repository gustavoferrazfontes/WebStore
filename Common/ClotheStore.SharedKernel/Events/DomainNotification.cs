﻿using ClotheStore.SharedKernel.Events.Interfaces;
using System;

namespace ClotheStore.SharedKernel.Events
{
    public class DomainNotification : IDomainEvent
    {

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            DateOccurred = DateTime.Now;
        }
        public DateTime DateOccurred { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}
