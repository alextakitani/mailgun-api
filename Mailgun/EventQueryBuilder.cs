using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailgun {

    // WIP

    public class FieldFilterResult {

        public FieldFilterResult(MailgunFilterFieldType fft, string value) {
            FilterFieldType = fft;
            FilterValue = value;
        }

        public MailgunFilterFieldType FilterFieldType { get; private set; }
        public string FilterValue { get; private set; }
    }

    public interface IExpression {
        string AsString { get; }
    }

    public interface IOperand : IExpression {
        string Value { get; }
    }
    
    //public interface IUnaryExpression : IExpression {}

    //public interface IBinaryExpression : IExpression {

    //    IExpression Left { get; }
    //    IExpression Right { get; }
         
    //}

    public class Operand : IOperand {

        public string Value { get; private set; }
        
        public Operand(string value) {
            Value = value;
        }
        
        public string AsString {
            get { return Value;}
        }
    }

    public class Not : IExpression {

        public IExpression Value { get; private set; }

        public Not(IExpression expression) {
            Value = expression;
        }
        public Not(IOperand expression) {
            Value = expression;
        }

        public string AsString {
            get {
                return (Value == null) ? "NOT " :  string.Format("NOT ({0})", Value.AsString);
            }
        }
    }

    public class Or : IExpression {
        private readonly List<IExpression> fExpressions = new List<IExpression>();
        public IExpression Left { get; private set; }
        public IExpression Right { get; private set; } 

         public Or(params IExpression[] args) {
            fExpressions.AddRange(args);
        }

        public Or(IExpression left, IExpression right) {
            fExpressions.Add(left);
            fExpressions.Add(right);
        }

        public string AsString {
            get {
                return string.Format("({0})", string.Join(" OR ", fExpressions.Select(q => q.AsString)));
            }
        }

    }

    public class And : IExpression {
        private readonly List<IExpression> fExpressions = new List<IExpression>();
        public IExpression Left { get; private set; }
        public IExpression Right { get; private set; }

        public And(params IExpression[] args) {
            fExpressions.AddRange(args);
        }

        public And(IExpression left, IExpression right) {
            fExpressions.Add(left);
            fExpressions.Add(right);
            Left = left;
            Right = right;
        }

        public string AsString {
            get {
                return string.Format("({0})", string.Join(" AND ", fExpressions.Select(q => q.AsString)));
            }
        }
    }

    public class EventQueryBuilder {

        readonly List<IExpression> expressions = new List<IExpression>();

        public EventQueryBuilder Not(IExpression expression = null) {
            expressions.Add(new Not(expression));
            return this;
        }

        public EventQueryBuilder Or(params IExpression[] args) {
            expressions.Add(new Or(args));
            return this;
        }

        public EventQueryBuilder Or(IExpression left, IExpression right) {
            expressions.Add(new Or(left, right));
            return this;
        }

        public EventQueryBuilder And(params IExpression[] args) {
            expressions.Add(new And(args));
            return this;
        }

        public EventQueryBuilder And(IExpression left, IExpression right) {
            expressions.Add(new And(left, right));
            return this;
        }

        public FieldFilterResult Build() {

            StringBuilder sb = new StringBuilder();
            foreach (var expression in expressions) {
                sb.Append(expression.AsString);
            }
            return new FieldFilterResult(MailgunFilterFieldType.Event, sb.ToString());
        }
    }

    public static class QueryBuilderExtensions {

        public static Operand ToOperand(this string value) {
            return new Operand(value);
        }

        public static Operand ToOperand(this MailgunEvent value) {
            return new Operand(value.ToName());
        }
    }

}
