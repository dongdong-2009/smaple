var PasswordStrenthValidatorEvaluateIsValid = function PasswordStrenthValidator$EvaluateIsValid(val){
    var controlValue = ValidatorTrim(ValidatorGetValue(val.controltovalidate));
    var strenthValue = 0;
    var multiType = -1;
    var rules = PasswordStrenthValidatorEvaluateIsValid.rules;
    for(var i = 0 ; i < rules.length ; i++){
        var matchCount = PasswordStrenthValidatorEvaluateIsValid._getMatchCount(rules[i].regex,controlValue);
        strenthValue += matchCount * rules[i].ratio;
        if(matchCount){
            multiType ++;
        }
    }
    strenthValue += PasswordStrenthValidatorEvaluateIsValid.multiType * multiType;    
    return (strenthValue >= val.passwordStrenth);
}
PasswordStrenthValidatorEvaluateIsValid._getMatchCount = function Validator$getMatchCount(reg,value){
    var cnt = 0;
    while (reg.exec(value) != null)
    {
        cnt++;
    }
    return cnt;
}

PasswordStrenthValidatorEvaluateIsValid.multiType = 20;
PasswordStrenthValidatorEvaluateIsValid.rules = [
    {
        regex:new RegExp("[a-z]", "g"),
        ratio:5
    },
    {
        regex:new RegExp("[0-9]", "g"),
        ratio:5
    },
    {
        regex:new RegExp("[A-Z]", "g"),
        ratio:5
    },
    {
        regex:new RegExp("[^a-z,A-Z,0-9,\x20]", "g"),
        ratio:10
    }
];