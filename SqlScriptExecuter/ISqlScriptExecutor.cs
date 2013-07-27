using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlScriptExecuter {
    public interface ISqlScriptExecutor {
        /// <summary>
        /// Connection String to your target Database
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Fullname of the your .sql files
        /// Remember your scripts should be set to Embbeded Resource
        /// </summary>
        string[] ScriptsFiles { get; set; }

        void ExecuteScripts();
    } //interface
}
