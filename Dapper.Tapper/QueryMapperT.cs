using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace Dapper.Tapper
{
    /// <summary>
    /// The QueryMapper allows developers to separate the mapping functionality of Dapper 
    /// from the actual querying process.
    /// </summary>
    /// <typeparam name="TReturn"></typeparam>
    public class QueryMapper<TReturn>
    {
        #region Constructors

        public QueryMapper()
        {

        }
      
        #endregion

        private const string DEFAULT_SPLITON = "id";

        public Func<SqlMapper.GridReader, IEnumerable<TReturn>> MappingFunc { get; private set; }

        /// <summary>
        /// Simplemap 
        /// equivalent to cnn.Query<T>(...)
        /// </summary>
        public QueryMapper<TReturn> SimpleMap()
        {
            this.MappingFunc = gridReader => { return gridReader.Read<TReturn>(); };

            return this;
        }

        /// <summary>
        /// Dynamicmap
        /// equivalent to cnn.Query<dynamic>(...)
        /// </summary>
        public QueryMapper<TReturn> DynamicMap(Func<dynamic, TReturn> mappingFunc)
        {
            this.MappingFunc = gridReader => { return gridReader.Read().Select<dynamic, TReturn>(s => mappingFunc.Invoke(s)); };

            return this;
        }

        /// <summary>
        /// Multimaps
        /// equivalent to cnn.Query<T1, T2, TReturn>(...)
        /// </summary>
        public QueryMapper<TReturn> MultiMap<T1, T2>(Func<T1, T2, TReturn> mappingFunc, string splitOn = DEFAULT_SPLITON)
        {
            this.MappingFunc = gridReader => { return gridReader.Read(mappingFunc, splitOn); };

            return this;
        }

        public QueryMapper<TReturn> MultiMap<T1, T2, T3>(Func<T1, T2, T3, TReturn> mappingFunc, string splitOn = DEFAULT_SPLITON)
        {
            this.MappingFunc = gridReader => { return gridReader.Read(mappingFunc, splitOn); };

            return this;
        }

        public QueryMapper<TReturn> MultiMap<T1, T2, T3, T4>(Func<T1, T2, T3, T4, TReturn> mappingFunc, string splitOn = DEFAULT_SPLITON)
        {
            this.MappingFunc = gridReader => { return gridReader.Read(mappingFunc, splitOn); };

            return this;
        }

        public QueryMapper<TReturn> MultiMap<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, TReturn> mappingFunc, string splitOn = DEFAULT_SPLITON)
        {
            this.MappingFunc = gridReader => { return gridReader.Read(mappingFunc, splitOn); };

            return this;
        }

        public QueryMapper<TReturn> MultiMap<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, TReturn> mappingFunc, string splitOn = DEFAULT_SPLITON)
        {
            this.MappingFunc = gridReader => { return gridReader.Read(mappingFunc, splitOn); };

            return this;
        }

        public QueryMapper<TReturn> MultiMap<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> mappingFunc, string splitOn = DEFAULT_SPLITON)
        {
            this.MappingFunc = gridReader => { return gridReader.Read(mappingFunc, splitOn); };

            return this;
        }
    }
}
