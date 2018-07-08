#pragma once

#include "DtoNative.h"

using namespace ManagedUtilsLibrary;

DtoNative Marshal(Dto^ dto);
Dto^ Marshal(DtoNative dto);
