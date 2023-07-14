namespace SLVS.DTO;

public abstract class FormModel
{
    /// <summary>
    ///     Validates the data transfer object based on their DataAnnotations
    /// </summary>
    /// <returns>List of FormModelErrors</returns>
    public List<FormModelError> Validate()
    {
        var errors = new List<FormModelError>();

        var properties = GetType().GetProperties();

        foreach (var p in properties)
        {
            var attributes = p.GetCustomAttributes(false);
            errors.Add(new FormModelError { Field = p.Name });

            foreach (var attr in attributes)
            {
                dynamic a = attr;

                if (a.IsValid(p.GetValue(this))) continue;

                var error = errors.First(x => x.Field == p.Name);
                error.Messages.Add(string.Format(a.ErrorMessage, p.Name));
            }
        }


        return errors;
    }
}