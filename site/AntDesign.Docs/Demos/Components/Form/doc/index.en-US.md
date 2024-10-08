﻿---
category: Components
type: Data Entry
cols: 1
title: Form
cover: https://gw.alipayobjects.com/zos/alicdn/ORmcdeaoO/Form.svg
---

High performance Form component with data scope management. Including data collection, verification, and styles.

## When to use

- When you need to create an instance or collect information.
- When you need to validate fields in certain rules.

## API
### Form
| Name | Description | Type | Default Value |
| --- | --- | --- | --- |
| Autocomplete| Whether input elements can by default have their values automatically completed by the browser. | string | on \| off | off  |
| Layout | Form Layout | [FormLayout](https://github.com/ant-design-blazor/ant-design-blazor/blob/master/components/form/types/FormLayout.cs) | FormLayout.Horizontal |
| LabelCol | label label layout, same as \<Col\> component, set span offset value | [ColLayoutParam](https://github.com/ant-design-blazor/ant-design-blazor/blob/master/components/form/ColLayoutParam.cs) |-|
| LabelColSpan | Same as LabelCol.Span | int |-|
| LabelColOffset | Same as LabelCol.Offset | int |-|
| WrapperCol | When you need to set the layout style for the input control, use this attribute. The usage is the same as labelCol | [ColLayoutParam](https://github.com/ant-design-blazor/ant-design-blazor/blob/master/components/form/ColLayoutParam.cs) |-|
| WrapperColSpan | Same as WrapperCol.Span | int |-|
| WrapperColOffset | Same as WrapperCol.Offset | int |-|
| Size | Set the size of the field component (antd component only) | small \| middle \| large | middle |
| Name | The name of the form, which will be used as the prefix of the form field id. In static render mode, also as `FromName` parameter of [EditForm](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/EditForm.cs#L96), specifying the Form Handler. | string |-|
| Method | Http method used to submit form | string | get |
| Model | Generic Object of Operation | T |-|
| Loading | Is the form loading | bool | false |
| Locale | Localization object | FormLocale | - |
| OnFinish | Submit Event | EventCallback\<EditContext\> |-|
| OnFinishFailed | Submission failure (verification failure) callback event | EventCallback\<EditContext\> |-|
| ValidateOnChange | Whether to verify when changing | bool | false |
| RequiredMark | Change how required/optional field labels are displayed on the form. | FormRequiredMark | FormRequiredMark.Required |

### FormItem
| Name | Description | Type | Default Value |
| --- | --- | --- | --- |
| Label | **label** Label text | string | Display or DisplayName characteristics of the input component |
| LabelTemplate | **label** Template | RenderFragment |-|
| LabelCol | **label** label layout, same as \<Col\> component, set span offset value | [ColLayoutParam](https://github.com/ant-design-blazor/ant-design-blazor/blob/master/components/form/ColLayoutParam.cs) |-|
| LabelAlign | **label** Label text alignment | left \| right | left |
| LabelColSpan | Same as LabelCol.Span | int |-|
| LabelColOffset | Same as LabelCol.Offset | int |-|
| WrapperCol | When you need to set the layout style for the input control, use this attribute, the usage is the same as labelCol | [ColLayoutParam](https://github.com/ant-design-blazor/ant-design-blazor/blob/master/components/form/ColLayoutParam.cs) |-|
| WrapperColSpan | Same as WrapperCol.Span | int |-|
| WrapperColOffset | Same as WrapperCol.Offset | int |-|
| NoStyle | No style when true, it is used as a pure field control | bool | false |
| Required | Whether it is required or not, true will generate * sign after label | bool | Required feature of input binding attribute |
| LabelStyle | **Label** Label Style | string |-|
| Rules | Validation rules, set the validation logic of the field | [FormValidationRule[]](https://github.com/ant-design-blazor/ant-design-blazor/blob/master/components/form/Validate/Rule/FormValidationRule.cs) |-|
| HasFeedback | Used in conjunction with the **validateStatus** property to display the verification status icon. It is recommended to use it only with the Input component | bool | false |
| ValidateStatus | Validation status, if not set, it will be automatically generated according to validation rules | [FormValidateStatus](https://github.com/ant-design-blazor/ant-design-blazor/blob/master/components/form/FormValidateStatus.cs) | FormValidateStatus.Default |
| Help | Prompt information | string | Automatically generated according to verification rules |


### Rules
Rules supports a config FormValidationRule[]

| Name | Description | Type |
| --- | --- | --- |
| DefaultField | Validate rule for all array elements. (FormItem not support now) | [FormValidationRule](en-US/components/form#Rule) |
| OneOf | Whether the value is one of specified values. | object\[] |
| Enum | The type of enum value, validte the value is one of the enum values | object\[] |
| Fields | Validate rule for child elements, valid when `type` is `Array` or `Object`(FormItem not support now) | Dictionary&lt;object, [FormValidationRule](en-US/components/form#Rule)> |
| Len | Length of String, Number, Array | decimal |
| Max | max length of `String`, `Number`, `Array` | decimal |
| Message | Error message. Will auto generate by ValidateMessages(see below) if not provided | string |
| Min | min length of `String`, `Number`, `Array` | decimal |
| Pattern | Regex pattern | string |
| Required | Required field | bool |
| Transform | Transform value to the rule before validation | Func&lt;object,object> |
| Type | Normally `String` \|`Number` \|`Boolean` \|`Url` \| `Email`. | RuleFieldType |
| ValidateTrigger | TODO | string \| string\[] |
| Validator |Customize validation rule. Accept ValidationResult as return see [example](en-US/components/form#components-form-demo-dynamic-rule) | Func&lt;FormValidationContext,ValidationResult> |


### FormValidateErrorMessages

For the Form component's multiple validation Settings, such as the DataAnnotations, Rules, and Requireed parameter, the error message template is obtained by default from the globalization file built into the component library. The following customizations are also supported:

1. The default value of the globalized language of the component can be modified by the Locale property of the Form
2. Implement the validation configuration using the DataAnnotations feature on the model, supporting the customization of ErrorMessage or ErrorMessageResourceName for modifying the feature.
3. The validation configuration is implemented using the FormItem setting Rules, which are customized via the Message attribute in the FormValidationRule.
4. Pass an error prompt template to a child component through the Form property in the ConfigProvider.


Example of custom message templates for DataAnnotations:

```csharp
public class Model
{
    [MaxLength(12,ErrorMessage ="A maximum of 12 characters can be entered")]
    [DisplayName("User Name")]
    public string Username { get; set; }

    [Required(ErrorMessageResourceName = nameof(Resources.App.PasswordValidation), ErrorMessageResourceType = typeof(Resources.App))]
    [Display(Name = nameof(Resources.App.Password), ResourceType = typeof(Resources.App))]
    [MaxLength(16)]
    public string Password { get; set; }
}
```

Example of modifying Locale:

```csharp
@using AntDesign.Form.Locale

<Form Locale="locale" />;

@code
{
    FormLocale locale = LocaleProvider.CurrentLocale.Form;

    protected override void OnInitialized()
    {
        locale.DefaultValidateMessages.Required = "❌ {0} is required.";
    }
}
```

Example of setting the ConfigProvider:

```csharp
//in App.Razor
var validateMessages = new FormValidateErrorMessages {
  Required = "'{0}' is Required!",
  // ...
};

var formConfig = new FormConfig {
    ValidateMessages = validateMessages
}

<ConfigProvider Form="formConfig">
  <Router AppAssembly="@typeof(Program).Assembly" PreferExactMatches="@true">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(MainLayout)">
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
  </Router>
</ConfigProvider>;
```

### GenerateFormItem
FormItem can be automatically generated by the 'TItem' type. currently supports automatic generation for string, DateTime, number, and enum type members, Support automatic generation of nested types. 
> **Notice:** This feature is in iteration, and incompatible changes may occur in subsequent releases.

| Name | Description                                                                                                                                                                                                                                 | Type                                      | Default Value |
| --- |---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------|------|
| ValidateRules | A generic delegate with one parameters, where the first parameter is of type PropertyInfo, and the return value is of type FormValidationRule[]?.                                                                                           | Func<PropertyInfo, FormValidationRule[]?> | null |
| Definitions | A generic delegate with two parameters, where the first parameter is of type PropertyInfo, the second parameter is of type TItem, and the return value is of type RenderFragment.                                                           | Func<PropertyInfo, TItem, RenderFragment>? | null |
| NotGenerate | A generic delegate with two parameters, where the first parameter is of type PropertyInfo, the second parameter is of type TItem, and the return value is of type bool. If the delegate returns true, automatic generation will be skipped. | Func<PropertyInfo, TItem, bool>?          | null |
| SubformStyle | Nested form style, default to Collapse style, optional Block style..                                                                                                                                                                        | string                                    | Collapse |

### Reference

IForm

| Name                                                         | Description                             | 
| ------------------------------------------------------------ | --------------------------------------- | 
| EditContext                                                 | Get the current EditContext from the Form. |
| IsModified                                                  |  Whether the form has been modified. |
| Model                                                       | The data object that the form is bound to. |
| Name                                                        | The name of the form. |
| Reset()                                                     | Reset the values and validation messages of all fields.  | 
| SetValidationMessages(string field, string[] errorMessages) | Set validation messages for a specific field. | 
| Submit()                                                    | Trigger `OnFinish` while all fields are valid, otherwise, trigger `OnFinishFailed`. |
| Validate()                                                  | Validate all fields.                             |


<style>
.code-box-demo .ant-form:not(.ant-form-inline):not(.ant-form-vertical) {
  max-width: 600px;
}
.markdown.api-container table td:nth-of-type(4) {
  white-space: nowrap;
  word-wrap: break-word;
}
</style>

<style>
  .site-form-item-icon {
    color: rgba(0, 0, 0, 0.25);
  }
  [data-theme="dark"] .site-form-item-icon {
    color: rgba(255,255,255,.3);
  }
</style>
