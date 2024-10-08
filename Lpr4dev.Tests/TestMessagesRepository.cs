﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lpr4dev.Data;
using Lpr4dev.DbModel;

namespace Lpr4dev.Tests
{
    internal class TestMessagesRepository : IMessagesRepository
    {
        public TestMessagesRepository(params Message[] messages)
        {
            Messages.AddRange(messages);
        }

        public List<DbModel.Message> Messages { get; } = new List<Message>();

        public Task DeleteAllMessages(string mailboxName)
        {
            Messages.Clear();
            return Task.CompletedTask;
        }

        public Lpr4devDbContext DbContext => throw new NotImplementedException();

        public Task DeleteMessage(Guid id)
        {
            Messages.RemoveAll(m => m.Id == id);
            return Task.CompletedTask;
        }

        public IQueryable<Message> GetAllMessages(bool unTracked = true)
        {
            return Messages.AsQueryable();
        }

        public IQueryable<Message> GetMessages(string mailboxName, bool unTracked = true)
        {
            return Messages.AsQueryable();
        }

        public Task MarkAllMessagesRead(string mailboxName)
        {
            foreach (var msg in Messages)
            {
                msg.IsUnread = false;
            }

            return Task.CompletedTask;
        }

        public Task MarkMessageRead(Guid id)
        {
            Messages.FirstOrDefault(m => m.Id == id).IsUnread = false;
            return Task.CompletedTask;
        }

        public Task<Message> TryGetMessageById(Guid id, bool tracked)
        {
            return Task.FromResult( Messages.SingleOrDefault(m => m.Id == id));
        }
    }
}