# Release Notes

## 4.0.0 - ?

Breaking changes:
- Table classes now under ByteDev.Cmd.Tables namespace.
- TablePosition is now CellPosition.

New features:
- Added new border style.
- Added Cell (Table now holds Cells type not strings)

Bug fixes:
- (None)

## 3.1.0 - 06 November 2019

Breaking changes:
- (None)

New features:
- Added CmdArgInfo.GetArgument(char).
- Added CmdArgInfo.GetArgument(string).
- Added Table.UpdateRow overload.

Bug fixes:
- Fixed null color handling.

## 3.0.1 - 05 November 2019

Breaking changes:
- (None)

New features:
- (None)

Bug fixes:
- Fix around retrieving Table rows and columns.

## 3.0.0 - 05 November 2019

Breaking changes:
- Table GetValue is now GetCell
- Table InsertValue is now UpdateCell
- TablePosition X is now Column.
- TablePosition Y is now Rows.

New features:
- Added Table.UpdateRow.
- Added Table.GetRow.
- Added Table.GetColumn.

Bug fixes:
- (None)


## 2.1.0 - 04 November 2019

Breaking changes:
- (None)

New features:
- Added concept of BorderStyle (IBorderStyle, BorderSingle, BorderDouble classes)
- Added MessagBox.BorderStyle property.
- Added Table class and the ability to write it in the Output class.
- Added Output.Write(char)
- Added Output.WriteLine(char)

Bug fixes:
- (None)

## 2.0.0 - 21 October 2019

Breaking changes:
- Removed HelpText from CmdArgInfo, is now public extension method on IList<CmdAllowedArg>

New features:
- (None)

Bug fixes:
- (None)

## 1.2.0 - 19 October 2019

Breaking changes:
- (None)

New features:
- Added IsRequired property to CmdAllowedArg.
- CmdArgInfo now checks that all required arguments have been supplied.

Bug fixes:
- (None)


## 1.1.1 - 07 October 2019

Breaking changes:
- (None)

New features:
- (None)

Bug fixes:
- Fix so all public types now have XML documentation.


## 1.1.0 - 06 October 2019

Breaking changes:
- (None)

New features:
- New Arguments namespace with command line argument handling functionality.

Bug fixes:
- Fix so dont display input key on any key press prompt.
- Fix so XML documentation is provided as part of package.

