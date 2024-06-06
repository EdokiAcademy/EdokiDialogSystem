# EdokiDialogSystem

## Overview
This repository contains a .NET library project that serves as a .dll provider for Unity3D usage. Here are some important points to consider when developing .dll files for Unity3D:

1. Pay attention to the platform chosen when importing into Unity.
2. In the .NET project, avoid using special namespaces such as Microsoft.VisualBasic.FileIO for CSV parsing.
3. **IMPORTANT:** When using properties, use a private field with a public property. Unity cannot read the auto-generated backing field of an auto property.
4. StringBuilder appears to be buggy when creating iOS builds.

## DialogSystemLibrary 
It's a library that loads story and play the dialog node by node. 
It can also parse .twee file and load in a story. 

## DialogConsole
A console app to test the library

## DialogSystemLibrary.test
Unit test for the library.

