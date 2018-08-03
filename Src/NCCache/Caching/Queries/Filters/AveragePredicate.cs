// Copyright (c) 2018 Alachisoft
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections;
using Alachisoft.NCache.Common.Enum;
using Alachisoft.NCache.Common.Queries;
using Alachisoft.NCache.Common.Resources;

namespace Alachisoft.NCache.Caching.Queries.Filters
{
    public class AveragePredicate : AggregateFunctionPredicate
    {
        public override bool ApplyPredicate(object o)
        {
            return false;
        }

        internal override void Execute(QueryContext queryContext, Predicate nextPredicate)
        {
            if (ChildPredicate != null)
                ChildPredicate.Execute(queryContext, nextPredicate);

            CacheEntry entry = null;

            decimal sum = 0;

            if (queryContext.InternalQueryResult.Count > 0)
            {
                if (queryContext.CancellationToken != null && queryContext.CancellationToken.IsCancellationRequested)
                    throw new OperationCanceledException(ExceptionsResource.OperationFailed);
                foreach (string key in queryContext.InternalQueryResult)
                {
                    if (queryContext.CancellationToken != null && queryContext.CancellationToken.IsCancellationRequested)
                        throw new OperationCanceledException(ExceptionsResource.OperationFailed);
                    CacheEntry cacheentry = queryContext.Cache.GetEntryInternal(key, false);
                    object attribValue = queryContext.Index.GetAttributeValue(key, AttributeName, cacheentry.IndexInfo);
                    if (attribValue != null)
                    {
                        Type type = attribValue.GetType();
                        if ((type == typeof(bool)) || (type == typeof(DateTime)) || (type == typeof(string)) || (type == typeof(char)))
                            throw new Exception("AVG can only be applied to integral data types.");

                        sum += Convert.ToDecimal(attribValue);
                    }

                }

                AverageResult avgResult = new AverageResult();
                avgResult.Sum = sum;
                avgResult.Count = queryContext.InternalQueryResult.Count;
                //put the count and the sum
                base.SetResult(queryContext, AggregateFunctionType.AVG, avgResult);
            }
            else
            {
                base.SetResult(queryContext, AggregateFunctionType.AVG, null);
            }
        }

        internal override AggregateFunctionType GetFunctionType()
        {
            return AggregateFunctionType.AVG;
        }
    }
}
