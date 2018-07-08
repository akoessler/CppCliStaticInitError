#include "stdafx.h"
#include <gcroot.h>
#include "Marshaller.h"

static gcroot<DtoFactory^> dtoFactory = gcnew DtoFactory();

DtoNative Marshal(Dto^ dto)
{
	return DtoNative(dto->Data);
}

Dto^ Marshal(DtoNative dto)
{
	//auto dtoFactory = gcnew DtoFactory();
	//return dtoFactory->CreateDto(dto.GetData());
	return dtoFactory->CreateDto(dto.GetData());
}
