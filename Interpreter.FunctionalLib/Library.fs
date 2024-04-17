namespace Interpreter.FunctionalLib

module ConjunctiveNormalForm =
  type Expression =
      | Var of int
      | Not of Expression
      | Or of Expression * Expression
      | And of Expression * Expression
      | Implies of Expression * Expression
      | Equiv of Expression * Expression
      | Xor of Expression * Expression

  let rec createCNF expression =
      let rec transform = function
          | Var _ as x -> x
          | Not(Var x) -> Not (Var x)
          | Not(Not x) -> transform x
          | Not(Or(a, b)) -> transform (And(Not a, Not b))
          | Not(And(a, b)) -> transform (Or(Not a, Not b))
          | Or(And(a, b), c) -> transform (And(Or(a, c), Or(b, c)))
          | Or(a, And(b, c)) -> transform (And(Or(a, b), Or(a, c)))
          | And(a, b) -> And(transform a, transform b)
          | Or(a, b) -> Or(transform a, transform b)
          | Implies(a, b) -> transform (Or(Not a, b))
          | Equiv(a, b) -> transform (And(Implies(a, b), Implies(b, a)))
          | Xor(a, b) -> transform (And(Or(Not a, Not b), Or(a, b)))
          | Not(Implies(a, b)) -> transform (And(a, Not b))
          | Not(Equiv(a, b)) -> transform(Xor(a, b))
          | Not(Xor(a, b)) -> transform (Equiv(a, b))
      let cnfExpression' = transform expression
      if expression = cnfExpression' then expression else createCNF cnfExpression'

  let rec cnfToList expression =
      match expression with
      | Var x -> [[x]]
      | Not (Var x) -> [[-x]]
      | And (a, b) -> cnfToList a @ cnfToList b
      | Or (a, b) -> List.map2 (fun x y -> x @ y) (cnfToList a) (cnfToList b)
      | _ -> failwith "Expression should be in CNF form only"