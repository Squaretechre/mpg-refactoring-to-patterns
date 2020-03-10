#ifndef TESTDOMBUILDER_H
#define TESTDOMBUILDER_H

#include "IOutputBuilder.h"
#include "ITestBuilder.h"

class TestDomBuilder : public ITestBuilder
{
private:
  std::unique_ptr<IOutputBuilder> CreateBuilder(std::string root) override;
};

#endif