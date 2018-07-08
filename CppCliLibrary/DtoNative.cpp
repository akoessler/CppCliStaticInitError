#include "stdafx.h"
#include "DtoNative.h"

DtoNative::DtoNative(int data)
{
	this->data = data;
}

DtoNative::~DtoNative()
{
}

int DtoNative::GetData()
{
	return this->data;
}
