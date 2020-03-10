#include "DomBuilder.h"

#include <string>

DomBuilder::DomBuilder(std::string root) : Root(root) {};

void DomBuilder::AddBelow(std::string tag)
{
}

void DomBuilder::AddAbove(std::string tag)
{
  throw 0;
}
