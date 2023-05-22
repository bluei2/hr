using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Eches.Hr.SharedKernal.Exceptions;

namespace Eches.Hr.SharedKernal.Utility
{
    public static class SqlQueryStringUtility
    {
        public readonly static string sqlKeyWordsBlackListRegex= 
            string.Join
            (
                "",
                new string[]
                {
                    @"(?<=\s)ADD(?=\s)",
                    @"|(?<=\s)ADD CONSTRAINT(?=\s)",
                    @"|(?<=\s)ALL(?=\s)",
                    @"|(?<=\s)ALTER(?=\s)",
                    @"|(?<=\s)ALTER COLUMN(?=\s)",
                    @"|(?<=\s)ALTER TABLE(?=\s)",
                    @"|(?<=\s)AND(?=\s)",
                    @"|(?<=\s)ANY(?=\s)",
                    //@"|(?<=\s)AS(?=\s)",
                    @"|(?<=\s)ASC(?=\s)",
                    @"|(?<=\s)BACKUP DATABASE(?=\s)",
                    @"|(?<=\s)BETWEEN(?=\s)",
                    @"|(?<=\s)CASE(?=\s)",
                    @"|(?<=\s)CHECK(?=\s)",
                    @"|(?<=\s)COLUMN(?=\s)",
                    @"|(?<=\s)CONSTRAINT(?=\s)",
                    @"|(?<=\s)CREATE(?=\s)",
                    @"|(?<=\s)CREATE DATABASE(?=\s)",
                    @"|(?<=\s)CREATE INDEX(?=\s)",
                    @"|(?<=\s)CREATE OR REPLACE VIEW(?=\s)",
                    @"|(?<=\s)CREATE TABLE(?=\s)",
                    @"|(?<=\s)CREATE PROCEDURE(?=\s)",
                    @"|(?<=\s)CREATE UNIQUE INDEX(?=\s)",
                    @"|(?<=\s)CREATE VIEW(?=\s)",
                    @"|(?<=\s)DATABASE(?=\s)",
                    @"|(?<=\s)DEFAULT(?=\s)",
                    @"|(?<=\s)DELETE(?=\s)",
                    @"|(?<=\s)DESC(?=\s)",
                    @"|(?<=\s)DISTINCT(?=\s)",
                    @"|(?<=\s)DROP(?=\s)",
                    @"|(?<=\s)DROP COLUMN(?=\s)",
                    @"|(?<=\s)DROP CONSTRAINT(?=\s)",
                    @"|(?<=\s)DROP DATABASE(?=\s)",
                    @"|(?<=\s)DROP DEFAULT(?=\s)",
                    @"|(?<=\s)DROP INDEX(?=\s)",
                    @"|(?<=\s)DROP TABLE(?=\s)",
                    @"|(?<=\s)DROP VIEW(?=\s)",
                    @"|(?<=\s)EXEC(?=\s)",
                    @"|(?<=\s)EXISTS(?=\s)",
                    @"|(?<=\s)FOREIGN KEY(?=\s)",
                    @"|(?<=\s)FROM(?=\s)",
                    @"|(?<=\s)FULL OUTER JOIN(?=\s)",
                    @"|(?<=\s)GROUP BY(?=\s)",
                    @"|(?<=\s)HAVING(?=\s)",
                    @"|(?<=\s)IN(?=\s)",
                    @"|(?<=\s)INDEX(?=\s)",
                    @"|(?<=\s)INNER JOIN(?=\s)",
                    @"|(?<=\s)INSERT INTO(?=\s)",
                    @"|(?<=\s)INSERT INTO SELECT(?=\s)",
                    @"|(?<=\s)IS NULL(?=\s)",
                    @"|(?<=\s)IS NOT NULL(?=\s)",
                    @"|(?<=\s)JOIN(?=\s)",
                    @"|(?<=\s)LEFT JOIN(?=\s)",
                    @"|(?<=\s)LIKE(?=\s)",
                    @"|(?<=\s)LIMIT(?=\s)",
                    @"|(?<=\s)NOT(?=\s)",
                    @"|(?<=\s)NOT NULL(?=\s)",
                    @"|(?<=\s)OR(?=\s)",
                    @"|(?<=\s)ORDER BY(?=\s)",
                    @"|(?<=\s)OUTER JOIN(?=\s)",
                    @"|(?<=\s)PRIMARY KEY(?=\s)",
                    @"|(?<=\s)PROCEDURE(?=\s)",
                    @"|(?<=\s)RIGHT JOIN(?=\s)",
                    @"|(?<=\s)ROWNUM(?=\s)",
                    //@"|(?<=\s)SELECT(?=\s)",
                    @"|(?<=\s)SELECT DISTINCT(?=\s)",
                    @"|(?<=\s)SELECT INTO(?=\s)",
                    @"|(?<=\s)SELECT TOP(?=\s)",
                    @"|(?<=\s)SET(?=\s)",
                    @"|(?<=\s)TABLE(?=\s)",
                    @"|(?<=\s)TOP(?=\s)",
                    @"|(?<=\s)TRUNCATE TABLE(?=\s)",
                    @"|(?<=\s)UNION(?=\s)",
                    @"|(?<=\s)UNION ALL(?=\s)",
                    @"|(?<=\s)UNIQUE(?=\s)",
                    @"|(?<=\s)UPDATE(?=\s)",
                    @"|(?<=\s)VALUES(?=\s)",
                    @"|(?<=\s)VIEW(?=\s)",
                    @"|(?<=\s)WHERE(?=\s)"
                }
            );

        /// <summary>
        /// Checks the provided query string for matches against a keyword black list. If any mathces are found an
        /// UnsafeQueryStringException with details on the matches against the black list is thrown
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static void CheckIfQuerySafe(string query)
        {
            var blackList = sqlKeyWordsBlackListRegex;
                
            var matches = Regex.Matches($" {query} ", blackList, RegexOptions.IgnoreCase);

            if (matches.Count > 0)
            {
                var matchesStringBuilder = new StringBuilder();
                var matchesString = 
                matches.Aggregate
                    (
                        matchesStringBuilder,
                        (accu, next) => accu.AppendLine($"- [{next.Value}] at: {next.Index}"),
                        accu => accu.ToString()
                    );
                var markedQuery = Regex.Replace($" {query} ", blackList, @">>$0<<" ,RegexOptions.IgnoreCase);
                throw new UnsafeQueryStringException(markedQuery, matchesString);
            }
        }

        public static bool IsQuerySafe(string query)
        {
            var blackList = sqlKeyWordsBlackListRegex;
                
            bool isMatch = Regex.IsMatch($" {query} ", blackList, RegexOptions.IgnoreCase);
            return !isMatch;
        }

        // TODO:: Create similar method for just checking if a forbidden string is matched?
        public static string CleanseSql(string query)
        {
            var wordsToRemoveRegex = sqlKeyWordsBlackListRegex;

            var cleansedQuery = Regex.Replace($" {query} ", wordsToRemoveRegex, string.Empty, RegexOptions.IgnoreCase).Trim();

            return cleansedQuery;
        }
    }
}
