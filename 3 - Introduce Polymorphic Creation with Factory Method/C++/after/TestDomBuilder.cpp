#include "TestDomBuilder.h"

#include "DomBuilder.h"

std::unique_ptr<IOutputBuilder> TestDomBuilder::CreateBuilder(std::string root)
{
  return std::unique_ptr<IOutputBuilder>(new DomBuilder(root));
}