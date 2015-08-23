#include <capstone.h>

extern "C" {
	__declspec(dllexport) cs_arm* CapstoneArmDetail(cs_detail *detail) {
		return &detail->arm;
	}

	__declspec(dllexport) cs_arm64* CapstoneArm64Detail(cs_detail *detail) {
		return &detail->arm64;
	}

	__declspec(dllexport) cs_x86* CapstoneX86Detail(cs_detail *detail) {
		return &detail->x86;
	}
}