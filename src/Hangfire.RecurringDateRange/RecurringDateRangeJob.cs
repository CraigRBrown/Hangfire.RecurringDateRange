﻿// Portions of this codebase have been copied/modified from the Hangfire project

// Hangfire.RecurringDateRange is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as 
// published by the Free Software Foundation, either version 3 
// of the License, or any later version.
// 
// Hangfire.RecurringDateRange is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public 
// License along with Hangfire. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hangfire.Common;
using Hangfire.RecurringDateRange.Extensions;
using Hangfire.RecurringDateRange.Server;
using Hangfire.States;

namespace Hangfire
{
    public static class RecurringDateRangeJob
    {
        private static readonly Lazy<RecurringDateRangeJobManager> Instance = new Lazy<RecurringDateRangeJobManager>(
            () => new RecurringDateRangeJobManager());

        public static void AddOrUpdate(
            Expression<Action> methodCall,
            Func<string> cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            AddOrUpdate(methodCall, cronExpression(), timeZone, queue, startDate, endDate);
        }

        public static void AddOrUpdate<T>(
            Expression<Action<T>> methodCall,
            Func<string> cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            AddOrUpdate(methodCall, cronExpression(), timeZone, queue, startDate, endDate);
        }

        public static void AddOrUpdate(
            Expression<Action> methodCall,
            string cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var job = Job.FromExpression(methodCall);
            var id = GetRecurringJobId(job);

            Instance.Value.AddOrUpdate(id, job, cronExpression, timeZone ?? TimeZoneInfo.Utc, queue, startDate, endDate);
        }

        public static void AddOrUpdate<T>(
            Expression<Action<T>> methodCall,
            string cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var job = Job.FromExpression(methodCall);
            var id = GetRecurringJobId(job);

            Instance.Value.AddOrUpdate(id, job, cronExpression, timeZone ?? TimeZoneInfo.Utc, queue, startDate, endDate);
        }

        public static void AddOrUpdate(
            string recurringJobId,
            Expression<Action> methodCall,
            Func<string> cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            AddOrUpdate(recurringJobId, methodCall, cronExpression(), timeZone, queue, startDate, endDate);
        }

        public static void AddOrUpdate<T>(
            string recurringJobId,
            Expression<Action<T>> methodCall,
            Func<string> cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            AddOrUpdate(recurringJobId, methodCall, cronExpression(), timeZone, queue, startDate, endDate);
        }

        public static void AddOrUpdate(
            string recurringJobId,
            Expression<Action> methodCall,
            string cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var job = Job.FromExpression(methodCall);
            Instance.Value.AddOrUpdate(recurringJobId, job, cronExpression, timeZone ?? TimeZoneInfo.Utc, queue, startDate, endDate);
        }

        public static void AddOrUpdate<T>(
            string recurringJobId,
            Expression<Action<T>> methodCall,
            string cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var job = Job.FromExpression(methodCall);
            Instance.Value.AddOrUpdate(recurringJobId, job, cronExpression, timeZone ?? TimeZoneInfo.Utc, queue, startDate, endDate);
        }

        public static void AddOrUpdate(
            Expression<Func<Task>> methodCall,
            Func<string> cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            AddOrUpdate(methodCall, cronExpression(), timeZone, queue, startDate, endDate);
        }

        public static void AddOrUpdate<T>(
            Expression<Func<T, Task>> methodCall,
            Func<string> cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            AddOrUpdate(methodCall, cronExpression(), timeZone, queue, startDate, endDate);
        }

        public static void AddOrUpdate(
            Expression<Func<Task>> methodCall,
            string cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var job = Job.FromExpression(methodCall);
            var id = GetRecurringJobId(job);

            Instance.Value.AddOrUpdate(id, job, cronExpression, timeZone ?? TimeZoneInfo.Utc, queue, startDate, endDate);
        }

        public static void AddOrUpdate<T>(
            Expression<Func<T, Task>> methodCall,
            string cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var job = Job.FromExpression(methodCall);
            var id = GetRecurringJobId(job);

            Instance.Value.AddOrUpdate(id, job, cronExpression, timeZone ?? TimeZoneInfo.Utc, queue, startDate, endDate);
        }
        
        public static void AddOrUpdate(
            string recurringJobId,
            Expression<Func<Task>> methodCall,
            Func<string> cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            AddOrUpdate(recurringJobId, methodCall, cronExpression(), timeZone, queue, startDate, endDate);
        }

        public static void AddOrUpdate<T>(
            string recurringJobId,
            Expression<Func<T, Task>> methodCall,
            Func<string> cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            AddOrUpdate(recurringJobId, methodCall, cronExpression(), timeZone, queue, startDate, endDate);
        }

        public static void AddOrUpdate(
            string recurringJobId,
            Expression<Func<Task>> methodCall,
            string cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var job = Job.FromExpression(methodCall);
            Instance.Value.AddOrUpdate(recurringJobId, job, cronExpression, timeZone ?? TimeZoneInfo.Utc, queue, startDate, endDate);
        }

        public static void AddOrUpdate(RecurringDateRangeJobOptions options)
        {
            Instance.Value.AddOrUpdate(options);
        }

        public static void AddOrUpdate<T>(
            string recurringJobId,
            Expression<Func<T, Task>> methodCall,
            string cronExpression,
            TimeZoneInfo timeZone = null,
            string queue = EnqueuedState.DefaultQueue,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var job = Job.FromExpression(methodCall);
            Instance.Value.AddOrUpdate(recurringJobId, job, cronExpression, timeZone ?? TimeZoneInfo.Utc, queue, startDate, endDate);
        }

        public static void RemoveIfExists(string recurringJobId)
        {
            Instance.Value.RemoveIfExists(recurringJobId);
        }

        public static void Trigger(string recurringJobId)
        {
            Instance.Value.Trigger(recurringJobId);
        }

        private static string GetRecurringJobId(Job job)
        {
            return $"{job.Type.ToGenericTypeString()}.{job.Method.Name}";
        }
    }
}
