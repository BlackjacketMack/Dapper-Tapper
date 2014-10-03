Dapper-Tapper
=============

Tapper adds (dare we say "taps into") fun and useful functionality to Dapper.  
We're porting this over from several projects, standardizing it and cleaning it up in the process.  

* **QueryMapper** - (ported) - Adds portable mapping definitions to objects without requiring <T1-T7> overloads.
* **TableT/Database** - (not ported yet) - Adds simple table structures and an expressive Sql Command library including the ability to add sql to standard expressions (e.g. INSERT INTO...WHERE id = @id AND (PartitionID = @partitionID)).



##QueryMapper

The below example shows how you may have a special implementation of Dapper's Query that 
might do something special such as caching.  Because of all the MutliMap overloads, this
can become a daunting a cluttered process.

By using the querymapper, you can bundle the mapping functionality you want and pass 
in that object which get used by Dapper's QueryMultiple.

This can save a lot of generic type pain!

<pre>
var queryMapper = new QueryMapper<Foo>().SimpleMap();
     
var myQuery = cnn.MyUniqueQueryImplementationThatCaches(sql,ars,queryMapper);
     
public static IEnumerable<T> MyUniqueQueryImplementationThatCaches<T>(this IDbConnection cnn,string sql, object param,QueryMapper<T> mapper)
{
    //handle caching however you might

    //query using QueryMultiple
    var qm = cnn.QueryMultiple(sql, param, transaction, commandTimeout, commandType);
    return mapper.MappingFunc.Invoke(qm);
}
</pre>