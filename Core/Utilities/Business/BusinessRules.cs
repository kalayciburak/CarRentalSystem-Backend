using System.Linq;
using Core.Utilities.Results;

namespace Core.Utilities.Business {
    public class BusinessRules {
        public static IResult Run(params IResult[] logics) {
            // foreach (var logic in logics) {
            //     if (!logic.Success) return logic;
            // }
            //
            // return null;

            return logics.FirstOrDefault(logic => !logic.Success);
        }
    }
}