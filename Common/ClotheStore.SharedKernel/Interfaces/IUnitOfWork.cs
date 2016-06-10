﻿namespace ClotheStore.SharedKernel.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
